using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BankCredit.BL;
using BankCredit.Models;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using BankCredit.BL;
using BankCredit.View;

namespace BankCredit
{
    public partial class Admin : Vieww
    {
        public String myuser;
        public Admin(String user)
        {
            myuser = user;
            InitializeComponent();
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.name = txtUserName.Text;
            user.epass = txtPassword.Text;
            user.salt = RandomString(32);
            user.isadmin = chkAdmin.Checked;

            p.AddUser(user);
            p.addRaport(myuser, "add user " + user.name);

            MessageBox.Show("Operation succesful");
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.DeleteUser(txtUserName.Text);
            p.addRaport(myuser, "delete user " + txtUserName.Text);
            MessageBox.Show("Operation succesful");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            User user = new User();
            user.name = txtUserName.Text;
            user.epass = txtPassword.Text;
            user.salt = RandomString(32);
            user.isadmin = chkAdmin.Checked;

            p.updateUser(user);
            p.addRaport(myuser, "update user "+ user.name);

            MessageBox.Show("Operation succesful");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IList<User> us = p.getUsers();
            dataGridView1.RowCount = 1;
            foreach (User u in us)
            {
                dataGridView1.Rows.Add(u.id, u.name, u.isadmin);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            RaportGenerator r;
            if (xmlbtn.Checked) { 
                 r = MyRapGen.generate("xml");
            }
            else
            {
                r = MyRapGen.generate("txt");
            }
            r.generate();


            //XMLs.Serialize(Console.Out, us);

            //Console.ReadKey(true);



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
