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

            //WsSrv.WsSrv service = new WsSrv.WsSrv();
            CpqApi.CpqApi cpq_service = new CpqApi.CpqApi();
            //wait 200 seconds:
            //service.Timeout = 200 * 1000;
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

        public static User User(User user, Credentials credentials)
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

            //push user
            User retVal = user;
            WsSrv.WsSrv service = new WsSrv.WsSrv();
            service.Timeout = 200 * 1000;

            XmlDocument xDoc = user.CreateXml();
            XmlNode response = service.UserAdministration(credentials.Login, credentials.Password, "ADDORUPDATE", xDoc);
            Console.WriteLine(response.InnerXml);

            return retVal;
        

        }

        public static LinkOpportunity LinkOpportunity(LinkOpportunity linkOpportunity, Credentials credentials, string orderId)
        {



            //< Crm >
            //  < OpportunityId > 892ADE6756HIX </ OpportunityId >
            //     < OpportunityName > Test Oppty </ OpportunityName >
            //      </ Crm >
            //push LinkOpportunity
            LinkOpportunity retVal = linkOpportunity;
            CpqApi.CpqApi cpq_service = new CpqApi.CpqApi();
            //wait 200 seconds:
            //service.Timeout = 200 * 1000;
            cpq_service.Timeout = 200 * 1000;

            XmlDocument xDoc = linkOpportunity.CreateXml();
            XmlNode response = cpq_service.LinkOpportunity(credentials.Login, credentials.Password, orderId, xDoc);
            Console.WriteLine(response.InnerXml);
            return retVal;

        }

        public static Company Company(Company company, Credentials credentials)
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


            //push Company
            Company retVal = company;
            WsSrv.WsSrv service = new WsSrv.WsSrv();
            service.Timeout = 200 * 1000;
            XmlDocument xDoc = company.CreateXml();
            XmlNode response = service.CompanyAdministration(credentials.Login, credentials.Password, "ADDORUPDATE", xDoc);
            Console.WriteLine(response.InnerXml);

            return retVal;
        }

       
    }
}
