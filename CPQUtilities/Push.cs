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

        public static void AddUser(string APIusername, string APIpassword, string endUserName, string endUserPassword, string endUserType, string endUserCompanyCode)
        {
            //adds a user to the database
            //variable definitons:
            //API* are variables for dev use; ie, APIusername = Andy's dev login, etc. 
            //endUser* refers to end user variables
            //note: per API:
            //endUserCompanyCode = Code of the Company User Belongs to (usually is the SAP number) Company must exist (be pre-configured by SAP CPQ administrator)
            //endUserType = Group User Belongs To (must be pre-configured by SAP CPQ Administrator)

            WsSrv.WsSrv service = new WsSrv.WsSrv();
            //wait 200 seconds:
            service.Timeout = 200 * 1000;

            XmlDocument xDoc = new XmlDocument();
            //     xDoc.LoadXml(string.Format(@"
            //<USERPROPERTIES> <USERNAME>{0}
            //"));
        }
    }
}
