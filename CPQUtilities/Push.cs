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
            

            XmlNode response = service.SimpleProductAdministration(credentials.Login, credentials.Password, "ADDORUPDATE", xDoc);
            Console.WriteLine(response.InnerXml); ;



            return retVal;


        }

        public static Customer Customer(Customer customer, Credentials credentials)
        {
            //default return value
            Customer retVal = customer;

            //adding a customer

            //complete list of WsSrv operations: https://www.webcomcpq.com/wsAPI/wssrv.asmx

            WsSrv.WsSrv service = new WsSrv.WsSrv();
            CpqApi.CpqApi cpq_service = new CpqApi.CpqApi();
            //wait 200 seconds:
            service.Timeout = 200 * 1000;
            cpq_service.Timeout = 200 * 1000;
            //  < Customers >
            //    < Customer >
            //      < Id > 23 </ Id >
            //      < ExternalId ></ ExternalId >
            //      < Active > 0 </ Active >
            //      < FirstName > Harry </ FirstName >
            //      < LastName > Bruce </ LastName >
            //      < CustomerType ></ CustomerType >
            //      < Company > Procter & amp; Gamble Company, The</Company>
            //      <Address1>Procter &amp; Gamble Plaza</Address1>
            //      <Address2></Address2>
            //      <City>Cincinnati</City>
            //      <Province></Province>
            //      <StateAbbrev>OH</StateAbbrev>
            //      <ZipCode>45402</ZipCode>
            //      <CountryAbbrev>US</CountryAbbrev>
            //      <TerritoryName></TerritoryName>
            //      <BusinessPhone>(513) 698-6421</BusinessPhone>
            //      <BusinessFax>(513) 983-4381</BusinessFax>
            //      <EMail></EMail>
            //      <OwnerID>234</OwnerID>
            //      <OwnerUserName>MitchB</OwnerUserName>
            //      <CRMAccountId>0036000000Kq8eU</CRMAccountId>
            //      <CRMContactId>0016000000F0qvQ</CRMContactId>
            //      <CustomFields>
            //	<CustomField>
            //	   <Name>CustomCode</Name>
            //	   <Value>AAA111</Value>
            //	</CustomField>
            //      </CustomFields>
            //    </Customer>

            XmlDocument xDoc = customer.CreateXml();

            XmlNode response = cpq_service.CustomerAdministration(credentials.Login, credentials.Password, "ADDORUPDATE", xDoc);
           //XmlNode response = service.SimpleProductAdministration(credentials.Login, credentials.Password, "ADDORUPDATE", xDoc);
            Console.WriteLine(response.InnerXml); ;

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
