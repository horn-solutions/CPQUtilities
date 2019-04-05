using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CPQUtilities
{

    

//<COMPANYPROPERTIES>
//  <COMPANYCODE>WBI</COMPANYCODE >
//  <NAME>Webcom, Inc</NAME>
//  <EMAILADDRESS>webmaster @webcominc.com</EMAILADDRESS>
//  <ADDRESS1>611 N Broadway</ADDRESS1>
//  <ADDRESS2 />
//  <CITY>Milwaukee</CITY>
//  <STATE>WI</STATE>
//  <ZIPCODE>53202</ZIPCODE>
//  <COUNTRY>United States</COUNTRY>
//  <PHONENUMBER>414-273-4442</PHONENUMBER>
//  <FAXNUMBER> 414-298-9248 </FAXNUMBER>
//  <IMAGE>Webcomlogo.gif</IMAGE>
//</COMPANYPROPERTIES>


    public class Company
    {
        public string CompanyCode { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Image { get; set; }


        public Company()
        {
            //defaults
        }



        public XmlDocument CreateXml()
        {
            XmlDocument retVal = new XmlDocument();

            XmlNode companyProperties = retVal.CreateElement("COMPANYPROPERTIES");
            retVal.AppendChild(companyProperties);


           

            Utility.AddIfNotEmptyOrNull(companyProperties, "COMPANYCODE", CompanyCode);
            Utility.AddIfNotEmptyOrNull(companyProperties, "NAME", Name);
            Utility.AddIfNotEmptyOrNull(companyProperties, "EMAILADDRESS", EmailAddress);
            Utility.AddIfNotEmptyOrNull(companyProperties, "ADDRESS1", Address1);
            Utility.AddIfNotEmptyOrNull(companyProperties, "ADDRESS2", Address2);
            Utility.AddIfNotEmptyOrNull(companyProperties, "CITY", City);
            Utility.AddIfNotEmptyOrNull(companyProperties, "STATE", State);
            Utility.AddIfNotEmptyOrNull(companyProperties, "ZIPCODE", ZipCode);
            Utility.AddIfNotEmptyOrNull(companyProperties, "COUNTRY", Country);
            Utility.AddIfNotEmptyOrNull(companyProperties, "PHONENUMBER", PhoneNumber);
            Utility.AddIfNotEmptyOrNull(companyProperties, "FAXNUMBER", FaxNumber);
            Utility.AddIfNotEmptyOrNull(companyProperties, "IMAGE", Image);

           

            return retVal;
        }

        public static User LoadFromXML(XmlDocument xdoc)
        {
            User retVal = new User();

            // read the xml into fields

            return retVal;
        }


    }

   


}
