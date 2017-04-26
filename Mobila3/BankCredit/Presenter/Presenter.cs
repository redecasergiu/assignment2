using BankCredit.Model;
using BankCredit.Models;
using BankCredit.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BankCredit.BL
{
    public class Presenter
    {
        ModelCall m;
        Vieww v;
        
         
        public Presenter(ModelCall model, Vieww view)
        {
            m = model;
            v = view;

            Vieww.p = this;
        }

        public void genRap(String type)
        {
            m.genRap(type);
        }

        public void Withdraw(Account account, double sum)
        {
            m.Withdraw( account,  sum);
        }

        public bool addOrder(int ci, String a, String d, String s)
        {
            return m.addOrder( ci,  a,  d,  s);
        }

        public bool addProduct(String n, String d, String c, int s, double pp, int ss)
        {
            return m.addProduct(n, d, c, s, pp, ss);
        }

        public bool updateProduct(String n, String d, String c, int s, double pp, int ss)
        {
           return m.updateProduct( n,  d,  c,  s,  pp,  ss);
        }

        public void deleteProduct(String n)
        {
            m.deleteProduct( n);
        }

        public IList<Product> getProducts()
        {

            return m.getProducts();
        }


        public void addProductToOrder(int ip, int ic, int c)
        {
            m.addProductToOrder( ip,  ic,  c);
        }


        internal string HashSHA1(string value)
        {
            return m.HashSHA1( value);
        }

        internal bool VerifyHash(string value, string hash)
        {
            return m.VerifyHash( value,  hash);
        }

        internal string GetMd5Hash(MD5 md5Hash, string input)
        {
            return m.GetMd5Hash( md5Hash,  input);

        }


        public User Login(string userName, string password)
        {
            return m.Login( userName,  password);
        }

        public void AddUser(User user)
        {
            m.AddUser( user);
        }

        public void addRaport(String name, String action)
        {
            m.addRaport( name,  action);
        }


        public void updateUser(User user)
        {
            m.updateUser( user);
        }

        public void DeleteUser(String username)
        {
            m.DeleteUser( username);
        }


        public IList<Account> GetAccountsForUser(int userId)
        {
            return m.GetAccountsForUser( userId);
        }

        public IList<User> getUsers()
        {
            return m.getUsers();
        }

        public IList<Rap> getRaports()
        {
            return m.getRaports();
        }
    }

}
