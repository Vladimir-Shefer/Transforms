using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transforms
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>

        private static void doS(Form1 form)
        {
            form.DialogResult = MessageBox.Show(
        "жеппа",
        "Сообщение",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information
       );
        }

        [MTAThread]


        static void Main()
        {

            

            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Data_Parser parser = new Data_Parser();

            
            UI u = new UI();
            Form1 form = new Form1();
            u.Put_UI_Form(form);
            
          
                       
            Connection connection = new Connection();
            connection.Set_Parser(parser);
            new Mediator( connection, u);
            
            Application.Run(form);

        }
    }
}
