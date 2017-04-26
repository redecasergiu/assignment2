using BankCredit.BL;
using BankCredit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BankCredit.Model
{
    public class ModelCall
    {

        public void genRap(String type)
        {
            RaportGenerator rapgen = MyRapGen.generate(type);
            rapgen.generate();
        }

        public void Withdraw(Account account, double sum)
        {

        }

        public bool addOrder(int ci, String a, String d, String s)
        {
            Order o = new Order();
            o.idcustomer = ci;
            o.address = a;
            o.deliverydate = d;
            o.status = s;

            DataAccess dal = new DataAccess();
            dal.addOrder(o);
            return false;

        }

        public bool addProduct(String n, String d, String c, int s, double pp, int ss)
        {
            Product p = new Product();
            p.name = n;
            p.description = d;
            p.color = c;
            p.size = s;
            p.price = pp;
            p.stock = ss;
            DataAccess dal = new DataAccess();
            if (p.isOk())
            {
                dal.addProduct(p);
                return false;
            }
            return true;
        }

        public bool updateProduct(String n, String d, String c, int s, double pp, int ss)
        {
            Product p = new Product();
            p.name = n;
            p.description = d;
            p.color = c;
            p.size = s;
            p.price = pp;
            p.stock = ss;
            DataAccess dal = new DataAccess();
            if (p.isOk())
            {
                dal.updateProduct(p);
                return false;
            }
            return true;
        }

        public void deleteProduct(String n)
        {
            Product p = new Product();
            p.name = n;
            DataAccess dal = new DataAccess();
            dal.deleteProduct(p);
        }

        public IList<Product> getProducts()
        {
            DataAccess dal = new DataAccess();
            return dal.getProducts();
        }


        public void addProductToOrder(int ip, int ic, int c)
        {
            ProductOrder po = new ProductOrder();
            po.cantitate = c;
            po.idcommand = ic;
            po.idproduct = ip;

            DataAccess dal = new DataAccess();
            dal.addProductToOrder(po);
            //return false;
        }


        internal string HashSHA1(string value)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.UTF8.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        internal bool VerifyHash(string value, string hash)
        {
            if (value != null && hash != null && hash.Equals(HashSHA1(value)))
            {
                return true;
            }
            return false;
        }

        internal string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }


        public User Login(string userName, string password)
        {
            DataAccess dal = new DataAccess();
            User user = dal.GetUser(userName);
            if (user != null)
            {
                String check = HashSHA1(password + user.salt);
                if (user.epass.Equals(check))
                {
                    return user;
                }
            }
            return null;
        }

        public void AddUser(User user)
        {
            user.epass = HashSHA1(user.epass + user.salt);

            DataAccess dal = new DataAccess();
            dal.AddUser(user);
        }

        public void addRaport(String name, String action)
        {
            DataAccess dal = new DataAccess();
            dal.addRaport(name, action);
        }


        public void updateUser(User user)
        {
            user.epass = HashSHA1(user.epass + user.salt);

            DataAccess dal = new DataAccess();
            dal.updateUser(user);
        }

        public void DeleteUser(String username)
        {
            DataAccess dal = new DataAccess();
            dal.deleteUser(username);
        }


        public IList<Account> GetAccountsForUser(int userId)
        {
            DataAccess dal = new DataAccess();
            return dal.GetAccountsForUser(userId);
        }

        public IList<User> getUsers()
        {
            DataAccess dal = new DataAccess();
            return dal.getUsers();
        }

        public IList<Rap> getRaports()
        {
            DataAccess dal = new DataAccess();
            return dal.getRaports();
        }
    }
}
