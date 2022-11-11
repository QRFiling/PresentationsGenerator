
namespace WindowsFormsApp4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LectionTextField = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PresentationThemeTextField = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AuthorTextField = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.LoadingLabel = new System.Windows.Forms.Label();
            this.AboutButton = new System.Windows.Forms.Button();
            this.SlideCountNumField = new WindowsFormsApp4.nNumeric();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SlideCountNumField)).BeginInit();
            this.SuspendLayout();
            // 
            // LectionTextField
            // 
            this.LectionTextField.BackColor = System.Drawing.Color.White;
            this.LectionTextField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LectionTextField.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LectionTextField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LectionTextField.Location = new System.Drawing.Point(18, 34);
            this.LectionTextField.MaxLength = 100000;
            this.LectionTextField.Multiline = true;
            this.LectionTextField.Name = "LectionTextField";
            this.LectionTextField.Size = new System.Drawing.Size(299, 283);
            this.LectionTextField.TabIndex = 0;
            this.LectionTextField.TextChanged += new System.EventHandler(this.LectionTextField_TextChanged);
            this.LectionTextField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LectionTextField_KeyDown);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(0)))));
            this.StartButton.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.StartButton.FlatAppearance.BorderSize = 2;
            this.StartButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(0)))));
            this.StartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(0)))));
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartButton.ForeColor = System.Drawing.Color.OrangeRed;
            this.StartButton.Location = new System.Drawing.Point(37, 542);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(302, 35);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Создать презентацию";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PresentationThemeTextField);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(37, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 53);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тема презентации";
            // 
            // PresentationThemeTextField
            // 
            this.PresentationThemeTextField.BackColor = System.Drawing.Color.White;
            this.PresentationThemeTextField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PresentationThemeTextField.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.PresentationThemeTextField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PresentationThemeTextField.Location = new System.Drawing.Point(18, 25);
            this.PresentationThemeTextField.Name = "PresentationThemeTextField";
            this.PresentationThemeTextField.Size = new System.Drawing.Size(299, 16);
            this.PresentationThemeTextField.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LectionTextField);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.Location = new System.Drawing.Point(37, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 337);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Текст лекции";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AuthorTextField);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox3.Location = new System.Drawing.Point(37, 103);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(166, 53);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Автор";
            // 
            // AuthorTextField
            // 
            this.AuthorTextField.BackColor = System.Drawing.Color.White;
            this.AuthorTextField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AuthorTextField.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.AuthorTextField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AuthorTextField.Location = new System.Drawing.Point(18, 24);
            this.AuthorTextField.Name = "AuthorTextField";
            this.AuthorTextField.Size = new System.Drawing.Size(131, 16);
            this.AuthorTextField.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.SlideCountNumField);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox4.Location = new System.Drawing.Point(214, 103);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(166, 53);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Слайдов";
            // 
            // LoadingLabel
            // 
            this.LoadingLabel.BackColor = System.Drawing.Color.Transparent;
            this.LoadingLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadingLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LoadingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LoadingLabel.Location = new System.Drawing.Point(0, 0);
            this.LoadingLabel.Name = "LoadingLabel";
            this.LoadingLabel.Size = new System.Drawing.Size(411, 606);
            this.LoadingLabel.TabIndex = 6;
            this.LoadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LoadingLabel.Visible = false;
            // 
            // AboutButton
            // 
            this.AboutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(0)))));
            this.AboutButton.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.AboutButton.FlatAppearance.BorderSize = 2;
            this.AboutButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(0)))));
            this.AboutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(0)))));
            this.AboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AboutButton.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AboutButton.ForeColor = System.Drawing.Color.OrangeRed;
            this.AboutButton.Location = new System.Drawing.Point(345, 542);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(35, 35);
            this.AboutButton.TabIndex = 7;
            this.AboutButton.Text = "i";
            this.AboutButton.UseVisualStyleBackColor = false;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // SlideCountNumField
            // 
            this.SlideCountNumField.BackColor = System.Drawing.Color.White;
            this.SlideCountNumField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SlideCountNumField.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.SlideCountNumField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SlideCountNumField.Location = new System.Drawing.Point(12, 25);
            this.SlideCountNumField.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.SlideCountNumField.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.SlideCountNumField.Name = "SlideCountNumField";
            this.SlideCountNumField.Size = new System.Drawing.Size(128, 19);
            this.SlideCountNumField.TabIndex = 2;
            this.SlideCountNumField.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(411, 606);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.LoadingLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Генератор презентаций из лекций";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SlideCountNumField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox LectionTextField;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox PresentationThemeTextField;
        private System.Windows.Forms.TextBox AuthorTextField;
        private nNumeric SlideCountNumField;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label LoadingLabel;
        private System.Windows.Forms.Button AboutButton;
    }
}

