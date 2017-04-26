﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BankCredit.BL;
using BankCredit.Models;
using BankCredit.View;

namespace BankCredit
{
    public partial class OrdinaryUser : Vieww
    {
        public OrdinaryUser()
        {
            InitializeComponent();
        }

        private void OrdinaryUser_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void create2_Click(object sender, EventArgs e)
        {
            try
            {
                String n = name2b.Text;
                String d = description2b.Text;
                String c = color2b.Text;
                int s = int.Parse(size2b.Text);
                double pp = double.Parse(price2b.Text);
                int ss = int.Parse(stock2b.Text);

                p.addProduct(n, d, c, s, pp, ss);
            }catch(Exception q)
            {
                MessageBox.Show("Eroare", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            
        }

        private void add_Click_1(object sender, EventArgs e)
        {
            try
            {
                String a = addressb.Text;
                String d = dateb.Value.ToString("yyyy-MM-dd"); ;
                int c = int.Parse(customeridb.Text);
                String s = statusb.Text;

                p.addOrder(c, a, d, s);
            }
            catch (Exception q)
            {
                MessageBox.Show("Eroare", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void id2b_TextChanged(object sender, EventArgs e)
        {

        }

        private void apld_Click(object sender, EventArgs e)
        {
            try
            {
                int idp = int.Parse(id2b.Text);
                int idc = int.Parse(idb.Text);
                int ca = int.Parse(cantitateb.Text);

                p.addProductToOrder(idp,idc,ca);
            }
            catch (Exception q)
            {
                MessageBox.Show("Eroare", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delete2_Click(object sender, EventArgs e)
        {
            try
            {
                String n = name2b.Text;

                p.deleteProduct(n);
            }
            catch (Exception q)
            {
                MessageBox.Show("Eroare", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void update_Click(object sender, EventArgs e)
        {

        }

        private void update2_Click(object sender, EventArgs e)
        {
            try
            {
                String n = name2b.Text;
                String d = description2b.Text;
                String c = color2b.Text;
                int s = int.Parse(size2b.Text);
                double pp = double.Parse(price2b.Text);
                int ss = int.Parse(stock2b.Text);

                p.updateProduct(n, d, c, s, pp, ss);
            }
            catch (Exception q)
            {
                MessageBox.Show("Eroare", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getpb_Click(object sender, EventArgs e)
        {
            IList<Product> ps = p.getProducts();
            dataGridView1.RowCount = 1;
            foreach (Product p in ps)
            {
                dataGridView1.Rows.Add(p.id, p.name, p.description, p.color, p.size, p.price, p.stock);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
