using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CPQUtilities
{
   public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }

        public string Login { get { return string.Format("{0}#{1}", Username, Domain); } }
        //public string Login2 { get { return string.Format("{0}@{1}", Username, Domain); } }

        public bool DoYouSeeMe()
        {

            //for use with WsSrv Web Reference
            bool retVal = false;

            WsSrv.WsSrv service = new WsSrv.WsSrv();
            //service.Url = urlList.SelectedItem.ToString();
            service.Timeout = 200 * 1000; //miliseconds

            string response = service.doUSeeMe(Login, Password);
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(response);
            retVal = xdoc.FirstChild.Name.Equals("ICANSEEYOU");


            return retVal;
        }

        public bool DoYouSeeMe2()
        {

            //for use with CPQApi Web Reference
            bool retVal = false;

            CpqApi.CpqApi cpq_service = new CpqApi.CpqApi();
            cpq_service.Timeout = 200 * 1000;

            string response = cpq_service.doUSeeMe(Login, Password);
            XmlDocument xdoc = new XmlDocument();
            Console.WriteLine(response);
            xdoc.LoadXml(response);
            retVal = xdoc.FirstChild.Name.Equals("ICANSEEYOU");

            return retVal;

        }

        public Credentials()
        {
            if (!File.Exists("Credentials.dat"))
            {
                StreamWriter sw= File.CreateText("Credentials.dat");
                sw.WriteLine("username");
                sw.WriteLine("password");
                sw.WriteLine("domain");
                sw.Flush();
                sw.Close();
                throw new Exception("Default credential file created");
            }
            StreamReader sr = File.OpenText("Credentials.dat");
            string fileContents = sr.ReadToEnd();
            string[] lines = fileContents.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            if (lines.GetUpperBound(0) != 2) throw new Exception("Credentials.dat does not contain the required 3 lines of username, password and domain");

            Username = lines[0];
            Password = lines[1];
            Domain = lines[2];
        }
    }
}
