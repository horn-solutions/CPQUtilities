using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CPQUtilities
{
    /*
        <USERPROPERTIES>
            <USERNAME>ksmith</USERNAME>
            <PASSWORD AllowSameAsExisting="1">xdF5460Bf</PASSWORD>
            <TITLE>Mr.</TITLE>
            <FIRSTNAME>Kyle</FIRSTNAME>
            <LASTNAME>Smith</LASTNAME>
            <TYPE>Sales</TYPE>
            <EMAILADDRESS>ksmith@mycompany.com</EMAILADDRESS>
            <ADDRESS1>Summer Street</ADDRESS1>
            <ADDRESS2 />
            <ADMINISTRATOR>TRUE</ADMINISTRATOR>
            <CITY>New Berlin</CITY>
            <STATE>WI</STATE>
            <ZIPCODE>53151</ZIPCODE>
            <COUNTRY>United States</COUNTRY>
            <PHONENUMBER>262-785-8320</PHONENUMBER>
            <FAXNUMBER />
            <COMPANYCODE>Callidus</COMPANYCODE>
            <MUSTCHANGEPASSWORD>0</MUSTCHANGEPASSWORD>
            <PASSWORDLOCKED>0</PASSWORDLOCKED>
            <DEFAULTDICTIONARY></DEFAULTDICTIONARY>
            <ORDERINGPARENT>jsmith</ORDERINGPARENT>
            <MANAGINGPARENT>msmith</MANAGINGPARENT>
            <APPROVINGPARENT>msmith</APPROVINGPARENT>
            <CrmUserId>CALLIDUS/CLESAR@CALLIDUS.COM</CrmUserId>
            <CrmName>CALLIDUS/CLESAR@CALLIDUS.COM</CrmName>
            <CrmUserName></CrmUserName>
            <CrmPassword>crm_123zfgTlm</CrmPassword>
        </USERPROPERTIES>
      */

    public class User
    {
        public string Username { get; set; }              //        
        public string Password { get; set; }              //       AllowSameAsExisting ="1"
        public string Title { get; set; }                 // 
        public string FirstName { get; set; }             // 
        public string LastName { get; set; }              // 
        public string Type { get; set; }                  // 
        public string EmailAddress { get; set; }          // 
        public string Address1 { get; set; }              // 
        public string Address2 { get; set; }              // 
        public bool Administrator { get; set; }           // 
        public string City { get; set; }                  // 
        public string State { get; set; }                 // 
        public string ZipCode { get; set; }               // 
        public string Country { get; set; }               // 
        public string PhoneNumber { get; set; }           // 
        public string FaxNumber { get; set; }             // 
        public string CompanyCode { get; set; }           // 
        public int MustChangePassword { get; set; }       // 
        public int PasswordLocked { get; set; }           // 
        public string DefaultDictionary { get; set; }     // 
        public string OrderingParent { get; set; }        // 
        public string ManagingParent { get; set; }        // 
        public string ApprovingParent { get; set; }       // 
        public string CrmUserId { get; set; }             // 
        public string CrmName { get; set; }               // 
        public string CrmUserName { get; set; }           // 
        public string CrmPassword { get; set; }           //

        public User()
        {
            //defaults
            DefaultDictionary = "USEnglish";
        }

        public XmlDocument CreateXml()
        {
            XmlDocument retVal = null;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<USERPROPERTIES>");
            sb.AppendLine(string.Format("  <USERNAME>{0}</USERNAME>", Username));
            sb.AppendLine(string.Format("  <PASSWORD AllowSameAsExisting='1'>{0}</PASSWORD>", Password));
            sb.AppendLine(string.Format("  <TITLE></TITLE>", Title));
            sb.AppendLine(string.Format("  <FIRSTNAME>{0}</FIRSTNAME>", FirstName));
            sb.AppendLine(string.Format("  <LASTNAME>{0}</LASTNAME>", LastName));
            sb.AppendLine(string.Format("  <TYPE>{0}</TYPE>", Type));
            sb.AppendLine(string.Format("  <EMAILADDRESS>{0}</EMAILADDRESS>", EmailAddress));
            sb.AppendLine(string.Format("  <ADDRESS1>{0}</ADDRESS1>", Address1));
            sb.AppendLine(string.Format("  <ADDRESS2>{0}</ADDRESS2>", Address2));
            sb.AppendLine(string.Format("  <ADMINISTRATOR>{0}</ADMINISTRATOR>", Administrator.ToString().ToUpper()));
            sb.AppendLine(string.Format("  <CITY>{0}</CITY>", City));
            sb.AppendLine(string.Format("  <STATE>{0}</STATE>", State));
            sb.AppendLine(string.Format("  <ZIPCODE>{0}</ZIPCODE>", ZipCode));
            sb.AppendLine(string.Format("  <COUNTRY>{0}</COUNTRY>", Country));
            sb.AppendLine(string.Format("  <PHONENUMBER>{0}</PHONENUMBER>", PhoneNumber));
            sb.AppendLine(string.Format("  <FAXNUMBER>{0}</FAXNUMBER>", FaxNumber));
            sb.AppendLine(string.Format("  <COMPANYCODE>{0}</COMPANYCODE>", CompanyCode));
            sb.AppendLine(string.Format("  <MUSTCHANGEPASSWORD>{0}</MUSTCHANGEPASSWORD>", MustChangePassword));
            sb.AppendLine(string.Format("  <PASSWORDLOCKED>{0}</PASSWORDLOCKED>", PasswordLocked));
            sb.AppendLine(string.Format("  <DEFAULTDICTIONARY>{0}</DEFAULTDICTIONARY>", DefaultDictionary));
            sb.AppendLine(string.Format("  <ORDERINGPARENT>{0}</ORDERINGPARENT>", OrderingParent));
            sb.AppendLine(string.Format("  <MANAGINGPARENT>{0}</MANAGINGPARENT>", ManagingParent));
            sb.AppendLine(string.Format("  <APPROVINGPARENT>{0}</APPROVINGPARENT>", ApprovingParent));
            sb.AppendLine(string.Format("  <CrmUserId>{0}</CrmUserId>", CrmUserId));
            sb.AppendLine(string.Format("  <CrmName>{0}</CrmName>", CrmName));
            sb.AppendLine(string.Format("  <CrmUserName>{0}</CrmUserName>", CrmUserName));
            sb.AppendLine(string.Format("  <CrmPassword>{0}</CrmPassword>", CrmPassword));
            sb.AppendLine("</USERPROPERTIES>");

            retVal = new XmlDocument();
            retVal.LoadXml(sb.ToString());
            return retVal;
        }

        public static Product LoadFromXML(XmlDocument xdoc)
        {
            Product retVal = new Product();

            // read the xml into fields

            return retVal;
        }

    }
}
