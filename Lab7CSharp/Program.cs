using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7CSharp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form1 = new Form1();
            form1.FormClosed += (sender, e) => OpenForm2();
            Application.Run(form1);
        }

        static void OpenForm2()
        {
            
            Form2 form2 = new Form2();
            form2.Load += (sender, e) => { /* Ваш код, який викликається при завантаженні Form2 */ };
            form2.FormClosed += (sender, e) => OpenForm3();
            form2.ShowDialog(); // Використовуйте ShowDialog() замість Application.Run() для Form2
        }
        static void OpenForm3()
        {

            Form3 form3 = new Form3();
            form3.Load += (sender, e) => { /* Ваш код, який викликається при завантаженні Form2 */ };
            form3.ShowDialog(); // Використовуйте ShowDialog() замість Application.Run() для Form2
        }
    }
}
