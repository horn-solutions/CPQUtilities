using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CPQUtilities
{


    //<Root>
    //  <SearchFields Priority = "1" >
    //    < SearchField > CRMAccountId </ SearchField >
    //    < SearchField > FirstName </ SearchField >
    //    < SearchField > StateAbbrev </ SearchField >
    //    < SearchCustomFields >

    //    < CustomField >

    //       < Name > CustomCode </ Name >

    //    </ CustomField >
    //    </ SearchCustomFields >
    //  </ SearchFields >
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
    //    <Customer>
    //      <Id>32</Id>
    //      <ExternalId></ExternalId>
    //      <FirstName>John</FirstName>
    //      <LastName>Steven</LastName>
    //      <CustomerType></CustomerType>
    //      <Company>Procter &amp; Gamble Company, The</Company>
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
    //      <OwnerID></OwnerID>
    //      <OwnerUserName>MitchB</OwnerUserName>
    //      <CRMAccountId></CRMAccountId>
    //      <CRMContactId></CRMContactId>
    //      <CustomFields>
    //	<CustomField>
    //	   <Name>CustomCode</Name>
    //	   <Value>BBB222</Value>
    //	</CustomField>
    //      </CustomFields>
    //    </Customer>
    //    <Customer>
    //      <Id>2223</Id>
    //      <ExternalId></ExternalId>
    //      <FirstName>Tomas</FirstName>
    //      <LastName>Johanson</LastName>
    //      <CustomerType></CustomerType>
    //      <Company>Procter &amp; Gamble Company, The</Company>
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
    //      <OwnerID></OwnerID>
    //      <OwnerUserName></OwnerUserName>
    //      <CRMAccountId>0036000000332fg</CRMAccountId>
    //      <CRMContactId>0016000000F3432</CRMContactId>
    //       <CustomFields>
    //	<CustomField>
    //	   <Name>CustomCode</Name>
    //	   <Value>CCC333</Value>
    //	</CustomField>
    //      </CustomFields>
    //    </Customer>
    //  </Customers>
    //</Root>


    public class Customer
    {

        //http://help.webcomcpq.com/doku.php?id=appendixd:customeradministrationwebmethod:customeradministrationdetails 

        public string SearchField { get; set; }              //  not required;  attribute: Priority ="1"-if set to 1, fields listed in SearchFields nodes have priority over ID and externalID nodes during search      
        public string CustomFieldName { get; set; }              //       
        public string ID { get; set; }                 // not required
        public string ExternalId { get; set; }             // not required
        public bool Active { get; set; }              // this will usually only be used when updating customer, but not likely in the initial implementation; if left out, then this node will default to True; not required
        public string FirstName { get; set; }                  // 
        public string LastName { get; set; }          // 
        public string Company { get; set; }              // 
        public string CustomerType { get; set; }              // 
        public string Address1 { get; set; }           // 
        public string Address2 { get; set; }                  // 
        public string City { get; set; }                 // 
        public string Province { get; set; }               // 
        public string StateAbbrev { get; set; }               // two letter code; must be predefined in CPQ Admin, otherwise will not be created/updated and result sent to API Caller
        public string ZipCode { get; set; }           // 
        public string CountryAbbrev { get; set; }            // three letter code; must be predefined in CPQ Admin, otherwise will not be created/updated and result sent to API Caller
        public string TerritoryName { get; set; }           //  must be predefined in CPQ Admin, otherwise will not be created/updated and result sent to API Caller
        public string BusinessPhone { get; set; }
        public string BusinessFax { get; set; }
        public string EMail { get; set; }
        public string OwnerID { get; set; }
        public string OwnerUserName { get; set; }
        public string CRMAccountId { get; set; }
        public string CRMContactId { get; set; }

        public Customer()
        {
            //defaults
            
        }

        public XmlDocument CreateXml()
        {

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
            XmlDocument retVal = new XmlDocument();

            //put in XML creation code here
            XmlNode rootNode = retVal.CreateElement("Root");
            retVal.AppendChild(rootNode);

            XmlNode userCustomers = retVal.CreateElement("Customers");
            rootNode.AppendChild(userCustomers);

            XmlNode userCustomer = retVal.CreateElement("Customer");
            userCustomers.AppendChild(userCustomer);

            Utility.AddIfNotEmptyOrNull(userCustomer, "Id", ID);
            Utility.AddIfNotEmptyOrNull(userCustomer, "ExternalId", ExternalId);
            Utility.AddIfNotEmptyOrNull(userCustomer, "Active", Active);
            Utility.AddIfNotEmptyOrNull(userCustomer, "FirstName", FirstName);
            Utility.AddIfNotEmptyOrNull(userCustomer, "LastName", LastName);
            Utility.AddIfNotEmptyOrNull(userCustomer, "CustomerType", CustomerType);
            Utility.AddIfNotEmptyOrNull(userCustomer, "Company", Company);
            Utility.AddIfNotEmptyOrNull(userCustomer, "Address1", Address1);
            Utility.AddIfNotEmptyOrNull(userCustomer, "Address2", Address2);
            Utility.AddIfNotEmptyOrNull(userCustomer, "City", City);
            Utility.AddIfNotEmptyOrNull(userCustomer, "Province", Province);
            Utility.AddIfNotEmptyOrNull(userCustomer, "StateAbbrev", StateAbbrev);
            Utility.AddIfNotEmptyOrNull(userCustomer, "ZipCode", ZipCode);
            Utility.AddIfNotEmptyOrNull(userCustomer, "CountryAbbrev", CountryAbbrev);
            Utility.AddIfNotEmptyOrNull(userCustomer, "TerritoryName", TerritoryName);
            Utility.AddIfNotEmptyOrNull(userCustomer, "BusinessPhone", BusinessPhone);
            Utility.AddIfNotEmptyOrNull(userCustomer, "BusinessFax", BusinessFax);
            Utility.AddIfNotEmptyOrNull(userCustomer, "Email", EMail);
            Utility.AddIfNotEmptyOrNull(userCustomer, "OwnerID", OwnerID);
            Utility.AddIfNotEmptyOrNull(userCustomer, "OwnerUserName", OwnerUserName);
            Utility.AddIfNotEmptyOrNull(userCustomer, "CRMAccountId", CRMAccountId);
            Utility.AddIfNotEmptyOrNull(userCustomer, "CRMContactId", CRMContactId);

            return retVal;
        }

        public static Customer LoadFromXML(XmlDocument xdoc)
        {
            Customer retVal = new Customer();

            // read the xml into fields

            return retVal;
        }

    }
}
