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
    public partial class Accounts : Vieww
    {
        internal User user;


        public Accounts()
        {
            InitializeComponent();
            dgvAccounts.AutoGenerateColumns = false;
        }

        private void Accounts_Load(object sender, EventArgs e)
        {
            if (user!=null)
            {
                user.Accounts = p.GetAccountsForUser(user.id);

                dgvAccounts.DataSource = user.Accounts;
            }
        }
    }
}
