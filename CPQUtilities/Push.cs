using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CPQUtilities
{
    public static class Push
    {
        public static Product Product(Product product, Credentials credentials) //(string APIusername, string APIpassword, string productName, string productPartNumber, string productDisplayType)
        {
            //default return value
            Product retVal = product;

            //adding a product

            //complete list of WsSrv operations: https://www.webcomcpq.com/wsAPI/wssrv.asmx



            WsSrv.WsSrv service = new WsSrv.WsSrv();
            //wait 200 seconds:
            service.Timeout = 200 * 1000;

            //                XmlDocument xDoc = new XmlDocument();
            //                xDoc.LoadXml(string.Format(@"
            //<Products>
            //    <Product>
            //        <Identificator>PartNumber</Identificator>
            //        <DisplayType>Simple</DisplayType>
            //        <PartNumber>Test {0}</PartNumber>
            //        <ProductType>Accessories</ProductType>
            //        <ProductName>
            //            <USEnglish><![CDATA[{0}]]></USEnglish>
            //        </ProductName>
            //        <StartDate>3/3/15</StartDate>
            //        <EndDate>5/5/18</EndDate>
            //        <Categories>
            //            <USEnglish><![CDATA[Test]]></USEnglish>
            //        </Categories>
            //    </Product>
            //</Products>
            //", productName));

            XmlDocument xDoc = product.CreateXml();


            XmlNode response = service.SimpleProductAdministration(credentials.Username, credentials.Password, "ADDORUPDATE", xDoc);



            return retVal;


        }

        //public static void adduser(string apiusername, string apipassword, string endusername, string enduserpassword, string endusertype, string endusercompanycode)
        //{
        //    adds a user to the database
        //    variable definitons:
        //    api* are variables for dev use; ie, apiusername = andy's dev login, etc. 
        //    enduser * refers to end user variables
        //    note: per api:
        //    endusercompanycode = code of the company user belongs to(usually is the sap number) company must exist(be pre - configured by sap cpq administrator)
        //    endusertype = group user belongs to(must be pre - configured by sap cpq administrator)

        //    wssrv.wssrv service = new wssrv.wssrv();
        //    wait 200 seconds:
        //    service.timeout = 200 * 1000;

        //    xmldocument xdoc = new xmldocument();
        //    xdoc.loadxml(string.format(@"
        //    <userproperties> <username>{0}
        //    "));
        //}
    }
}
