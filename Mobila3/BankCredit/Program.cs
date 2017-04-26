using BankCredit.BL;
using BankCredit.Model;
using BankCredit.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BankCredit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Vieww v = new Login();
                ModelCall m = new ModelCall();
                Presenter p = new Presenter(m, v);
                Application.Run(v);
            }
            catch(Exception e) { MessageBox.Show(e.Message);
            }
        }
    }
}
