using BankCredit.BL;
using BankCredit.Models;
using BankCredit.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace BankCredit
{
    

    public partial class Login : Vieww
    {

        public Login()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            

            User user = p.Login(txtUser.Text, txtPassword.Text);

            if (user != null)
                if (user.isadmin)
                {
                    Vieww adminForm = new Admin(txtUser.Text);
                    //adminForm.p = p;
                    adminForm.Show();
                }
                else
                {
                    //Accounts accountsForm = new Accounts();
                    // accountsForm.user = user;
                    //accountsForm.Show();
                    Vieww ou = new OrdinaryUser();
                    //ou.p = p;
                    ou.Show();
                }
            else { }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
