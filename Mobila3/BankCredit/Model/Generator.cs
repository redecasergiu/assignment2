using BankCredit.BL;
using BankCredit.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BankCredit.BL
{
    public interface RaportGenerator
    {
        void generate();
    }

    public class TextGenerator : RaportGenerator
    {
        public void generate() {
            DataAccess dal = new DataAccess();
            IList<Rap> us = dal.getRaports();
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("D:\\32\\PS\\proiecte\\assignment2\\sursa_b\\Mobila3\\rap.txt"))
            {
                foreach (Rap rr in us)
                {
                    file.WriteLine("User: " + rr.user + ";   Actiune: " + rr.action + ";   Data:" + rr.time);
                }
            }
        }
    }

    public  class XmlGenerator : RaportGenerator
    {
        public void generate()
        {
            DataAccess dal = new DataAccess();
            IList<Rap> us = dal.getRaports();

            XmlSerializer XMLs = new XmlSerializer(us.GetType());
            XmlDocument xmlDocument = new XmlDocument();

            using (MemoryStream stream = new MemoryStream())
            {
                XMLs.Serialize(stream, us);
                stream.Position = 0;
                xmlDocument.Load(stream);
                xmlDocument.Save("D:\\32\\PS\\proiecte\\assignment2\\sursa_b\\Mobila3\\rap.xml");
                stream.Close();
            }


        }
    }

    public  class MyRapGen
    {
        public static RaportGenerator generate (String tip)
        {
            if (tip.Equals("xml"))
                return new XmlGenerator();
            else
                return new TextGenerator();
        }
    }
}
