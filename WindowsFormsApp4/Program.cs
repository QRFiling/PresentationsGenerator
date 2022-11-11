using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            Application.Run(new Form1());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Application.OpenForms.OfType<Form1>().First().Hide();

            MessageBox.Show($"Поздравляю, у нас ошибка:{Environment.NewLine}{e.Exception.Message}",
                "Караул", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Application.Restart();
        }
    }
}
