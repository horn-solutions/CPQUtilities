using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQUtilities
{
   public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }

        public string Login { get { return string.Format("{0}#{1}", Username, Domain); } }

        public void DoYouSeeMe()
        {
            WsSrv.WsSrv service = new WsSrv.WsSrv();
            //service.Url = urlList.SelectedItem.ToString();
            service.Timeout = 200 * 1000; //miliseconds

            string response = service.doUSeeMe(Login, Password);
            Console.WriteLine("Check Login: " + response);
        }

        public Credentials()
        {
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
