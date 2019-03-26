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
            XmlDocument retVal = new XmlDocument();

            XmlNode userProperties = retVal.CreateElement("USERPROPERTIES");
            retVal.AppendChild(userProperties);


            Utility.AddIfNotEmptyOrNull(userProperties, "USERNAME", Username);

            XmlNode pw = Utility.AddIfNotEmptyOrNull(userProperties, "PASSWORD", Password);
            if (pw != null)
            {
                XmlAttribute asae = retVal.CreateAttribute("AllowSameAsExisting");
                asae.InnerText = "1";
                pw.Attributes.Append(asae);
            }

            Utility.AddIfNotEmptyOrNull(userProperties, "TITLE", Title);
            Utility.AddIfNotEmptyOrNull(userProperties, "FIRSTNAME", FirstName);
            Utility.AddIfNotEmptyOrNull(userProperties, "LASTNAME", LastName);
            Utility.AddIfNotEmptyOrNull(userProperties, "TYPE", Type);
            Utility.AddIfNotEmptyOrNull(userProperties, "EMAILADDRESS", EmailAddress);
            Utility.AddIfNotEmptyOrNull(userProperties, "ADDRESS1", Address1);
            Utility.AddIfNotEmptyOrNull(userProperties, "ADDRESS2", Address2);
            Utility.AddIfNotEmptyOrNull(userProperties, "ADMINISTRATOR", Administrator);
            Utility.AddIfNotEmptyOrNull(userProperties, "CITY", City);
            Utility.AddIfNotEmptyOrNull(userProperties, "STATE", State);
            Utility.AddIfNotEmptyOrNull(userProperties, "ZIPCODE", LastName);
            Utility.AddIfNotEmptyOrNull(userProperties, "COUNTRY", LastName);
            Utility.AddIfNotEmptyOrNull(userProperties, "PHONENUMBER", LastName);
            Utility.AddIfNotEmptyOrNull(userProperties, "FAXNUMBER", LastName);
            Utility.AddIfNotEmptyOrNull(userProperties, "COMPANYCODE", LastName);
            Utility.AddIfNotEmptyOrNull(userProperties, "MUSTCHANGEPASSWORD", LastName);
            Utility.AddIfNotEmptyOrNull(userProperties, "PASSWORDLOCKED", LastName);
            Utility.AddIfNotEmptyOrNull(userProperties, "DEFAULTDICTIONARY", LastName);
            Utility.AddIfNotEmptyOrNull(userProperties, "ORDERINGPARENT", LastName);
            Utility.AddIfNotEmptyOrNull(userProperties, "MANAGINGPARENT", LastName);
            Utility.AddIfNotEmptyOrNull(userProperties, "APPROVINGPARENT", LastName);
            Utility.AddIfNotEmptyOrNull(userProperties, "CrmUserId", LastName);
            Utility.AddIfNotEmptyOrNull(userProperties, "CrmName", LastName);
            Utility.AddIfNotEmptyOrNull(userProperties, "CrmUserName", LastName);
            Utility.AddIfNotEmptyOrNull(userProperties, "CrmPassword", LastName);

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
