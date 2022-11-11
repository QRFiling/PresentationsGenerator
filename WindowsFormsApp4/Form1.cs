using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ControlsSettings();
        }

        void ControlsSettings()
        {
            foreach (var item in Controls.OfType<GroupBox>())
            {
                item.Controls[0].GotFocus += (s, e) =>
                {
                    foreach (var item2 in Controls.OfType<GroupBox>())
                        item2.ForeColor = Color.FromArgb(64, 64, 64);

                    item.ForeColor = Color.OrangeRed;
                };
            }

            foreach (var item in Controls.OfType<Button>())
                item.GotFocus += (s, e) => PresentationThemeTextField.Focus();

            AuthorTextField.Text = Environment.UserName;
        }

        string ImagesFolderPath = string.Empty;

        async Task<string[]> DownloadPictures()
        {
            using (WebClient web = new WebClient() { Encoding = Encoding.UTF8 })
            {
                LoadingLabel.Text = "Ожидание ответа от yandex.images...";
                string url = "https://yandex.ru/images/search?text=" + PresentationThemeTextField.Text;
                string responce = await web.DownloadStringTaskAsync(url);

                var m = Regex.Matches(responce, @"<(?<Tag_Name>(a)|img)\b[^>]*?\b(?<URL_Type>(?(1)href|src))\s*=\s*(?:""(?<URL>(?:\\""|[^""])*)""|'(?<URL>(?:\\'|[^'])*)')");
                string[] links = m.OfType<Match>().Where(w => w.Groups[0].Value.Contains("serp-item__thumb justifier__thumb")).Select(s => "http:" + s.Groups[4].Value.Replace("amp;", "&")).ToArray();

                ImagesFolderPath = $@"{Path.GetDirectoryName(saveFileDialog1.FileName)}\Images {DateTime.Now:d}";
                string[] paths = new string[(int)(SlideCountNumField.Value - 2)];

                DirectoryInfo directory = Directory.CreateDirectory(ImagesFolderPath);
                File.SetAttributes(ImagesFolderPath, FileAttributes.Hidden);

                for (int i = 0; i < paths.Length; i++)
                {
                    LoadingLabel.Text = $"Скачивание изображений... ({i + 1})";           
                    paths[i] = $@"{directory.FullName}\{i}.png";
                    await web.DownloadFileTaskAsync(new Uri(links[i]), paths[i]);
                }

                return paths;
            }
        }

        string CutText(string text)
        {
            string original = Regex.Replace(text, @"\(.+\)", string.Empty);
            string result = string.Empty;

            bool theme = true;
            var m = Regex.Matches(original, @"\bтема\b", RegexOptions.IgnoreCase);

            if (m.Count == 1)
            {
                m = Regex.Matches(original, @"\bконспект лекции\b", RegexOptions.IgnoreCase);
                theme = false;
            }

            string noHeader = original.Substring(m.Count > 0 ? m[theme ? 1 : 0].Index : 0);
            string[] lines = noHeader.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            bool plan = false;
            int planNum = 0;

            foreach (var item in lines)
            {
                if (item.ToLower().Contains("конспект"))
                    continue;
                
                string line = string.Empty;

                if (item.ToLower().Contains("план"))
                {
                    plan = true;
                    continue;
                }

                if (plan)
                {
                    int.TryParse(item[0].ToString(), out int num);

                    if (num < planNum)
                    {
                        planNum = 0;
                        plan = false;
                    }
                    else
                    {
                        planNum = num;
                        continue;
                    }
                }

                if (item.ToLower().Contains("рис.") || item.ToLower().Contains("рисунок")) continue;
                if (item.ToLower().Contains("контрольные вопросы") || item.ToLower().Contains("литература")) break;

                line += item;
                result += (line.Length == 0 || result.Length == 0 ? string.Empty : Environment.NewLine) + line;
            }

            return result;
        }

        async void button2_Click(object sender, EventArgs e)
        {
            string[] sentences = LectionTextField.Text.Split(new string[]
                { ".", "!", "?", ";", "..." }, StringSplitOptions.None).Where(w => !string.IsNullOrWhiteSpace(w)).ToArray();

            if (Controls.OfType<GroupBox>().Any(a => string.IsNullOrWhiteSpace(a.Controls[0].Text)))
            {
                MessageBox.Show("Все поля должны быть заполнены", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sentences.Length < SlideCountNumField.Value - 2)
            {
                MessageBox.Show($"Слишком мало текста для {SlideCountNumField.Value} слайдов", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.InitialDirectory = desktop;
            saveFileDialog1.FileName = PresentationThemeTextField.Text;
            saveFileDialog1.Filter = "Power Point|*.pptx";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadingLabel.Visible = true;
                LoadingLabel.BringToFront();

                string[] paths = await DownloadPictures();
                await Task.Run(() => { CreatePresentation(sentences, paths); });

                LoadingLabel.Visible = false;
                LoadingLabel.SendToBack();

                if (Directory.Exists(ImagesFolderPath))
                    Directory.Delete(ImagesFolderPath, true);

                DialogResult result = MessageBox.Show("Презентация готова! Открыть её?",
                    Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    Process.Start(saveFileDialog1.FileName);
            }
        }

        void CreatePresentation(string[] sentences, string[] imagePaths)
        {
            LoadingLabel.Text = "Создание презентации...";
            int slideCount = (int)(SlideCountNumField.Value - 1);
            Color pastel = GetRandomPastelColor();

            int backgroundColor = ColorTranslator.ToOle(ControlPaint.LightLight(ControlPaint.LightLight(pastel)));
            int textColor = ColorTranslator.ToOle(ControlPaint.Dark(pastel));

            DateTime presentationCreateStartTime = DateTime.Now;
            Microsoft.Office.Interop.PowerPoint.Application pptApplication = new Microsoft.Office.Interop.PowerPoint.Application();

            Slides slides; _Slide slide; TextRange objText;
            Presentation pptPresentation = pptApplication.Presentations.Add(MsoTriState.msoFalse);

            CustomLayout customLayout = pptPresentation.SlideMaster.CustomLayouts[PpSlideLayout.ppLayoutText];
            CustomLayout customLayout2 = pptPresentation.SlideMaster.CustomLayouts[1];

            AddStartSlide(1, PresentationThemeTextField.Text, "Автор презентации: " + AuthorTextField.Text);

            void AddStartSlide(int index, string s1, string s2)
            {
                slides = pptPresentation.Slides;
                slide = slides.AddSlide(index, customLayout2);

                slide.FollowMasterBackground = MsoTriState.msoFalse;
                slide.Background.Fill.ForeColor.RGB = textColor;

                objText = slide.Shapes[1].TextFrame.TextRange;
                objText.Text = s1;
                objText.Font.Color.RGB = backgroundColor;
                objText.Font.Name = "Montserrat";
                objText.Font.Bold = MsoTriState.msoTrue;

                if (!string.IsNullOrEmpty(s2))
                {
                    objText = slide.Shapes[2].TextFrame.TextRange;
                    objText.Text = s2;
                    objText.Font.Color.RGB = backgroundColor;
                    objText.Font.Name = "Montserrat";
                    objText.Font.Bold = MsoTriState.msoFalse;
                }
                else
                {
                    slide.Shapes[1].Top = 150;
                    slide.Shapes[2].Delete();
                }
            }

            for (int i = 1; i < slideCount; i++)
            {
                LoadingLabel.Text = $"Добавление слайдов... ({i})";
                slide = slides.AddSlide(i + 1, customLayout);

                slide.Shapes[2].Left = i % 2 == 0 ? 450 : 60;
                slide.Shapes[2].Top = 100;
                slide.Shapes[2].Width = 450;

                slide.FollowMasterBackground = MsoTriState.msoFalse;
                slide.Background.Fill.ForeColor.RGB = backgroundColor;

                objText = slide.Shapes[2].TextFrame.TextRange;
                slide.Shapes[1].Delete();

                string text = string.Join(".", sentences.Skip((i - 1) * sentences.Length / slideCount).Take(sentences.Length / slideCount)).Trim();
                text = text.Length > 800 ? text.Remove(800) + "..." : text;

                objText.Text = text;
                objText.ParagraphFormat.Bullet.Visible = MsoTriState.msoFalse;

                objText.Font.Name = "Montserrat";
                objText.Font.Color.RGB = textColor;
                objText.Font.Size = 15;

                slide.Shapes.AddPicture(imagePaths[i - 1], MsoTriState.msoFalse,
                    MsoTriState.msoTrue, i % 2 == 0 ? 60 : 550, 120, 300, 300);
            }

            AddStartSlide(slideCount + 1, "Спасибо за внимание!", string.Empty);
            LoadingLabel.Text = "Сохранение презентации...";
            pptPresentation.SaveAs(saveFileDialog1.FileName, PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

            pptPresentation.Close();
            pptApplication.Quit();

            foreach (var item in Process.GetProcessesByName("POWERPNT").Where(w => w.StartTime > presentationCreateStartTime))
                item.Kill();
        }

        Color GetRandomPastelColor()
        {
            Random random = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0));
            Color mix = Color.DarkGray;

            int red = random.Next(256);
            int green = random.Next(256);
            int blue = random.Next(256);

            red = (red + mix.R) / 2;
            green = (green + mix.G) / 2;
            blue = (blue + mix.B) / 2;

            return Color.FromArgb(red, green, blue);
        }

        void LectionTextField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                e.Handled = e.SuppressKeyPress = true;
                LectionTextField.SelectAll();
            }
        }

        void LectionTextField_TextChanged(object sender, EventArgs e)
        {
            Size size = Size.Round(TextRenderer.MeasureText(LectionTextField.Text, LectionTextField.Font,
                LectionTextField.ClientSize, TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak));

            LectionTextField.ScrollBars = size.Height > LectionTextField.Height ?
                ScrollBars.Vertical : ScrollBars.None;
        }

        void AboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Эта утилита создаёт презентацию PowerPoint из текста лекции, попутно вставляя картинки из интернета и " +
                "генерируя оформление. Она призвана облегчить процесс создания презентаций на основе лекций.\n\r\n\rДля работы нужен " +
                "установленный PowerPoint и подключение к интернету!\n\r\n\rАвтор: Рыжкин Максим (QR Filing)", "О программе",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public partial class nNumeric : NumericUpDown
    {
        protected override void OnResize(EventArgs e)
        {
            var buttons = Controls[0];
            var edit = Controls[1];
            buttons.Visible = false;
            edit.MinimumSize = new Size(Width - edit.Left * 2, 0);
            edit.Width = Width;
        }
    }
}
