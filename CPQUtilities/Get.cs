using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CPQUtilities
{
    public static class Get
    {

        //login issues persist for CPQQPI login attempts.

        public static String Catalogue(Credentials credentials)
        {

            //http://help.webcomcpq.com/doku.php?id=appendixd:get_catalogue:result_xml_examples

            //returns the XML of the entire Catalogue.
            //note, this can quickly exceed the limits of XML, and may not be the best method to get all items. A better way is likely to just export Products using the 
            //CPQ native interface.
            string retVal = "";

            CpqApi.CpqApi cpq_service = new CpqApi.CpqApi();
            cpq_service.Timeout = 200 * 1000;
            retVal = cpq_service.GetCatalogue(credentials.Login, credentials.Password);

            return retVal;
        }

        public static String GetQuoteData(Credentials credentials, string cartCompositeNumber, int? revNumber)
        {
            //http://help.webcomcpq.com/doku.php?id=appendixd:get_quote_data:get_quote_data

            //returns general quote data (including main/line items), actions, key attributes, product types, 
            //promo codes, additional discounts, markets, shippings, customer data and customer fields

            string retVal = "";

            CpqApi.CpqApi cpq_service = new CpqApi.CpqApi();
            cpq_service.Timeout = 200 * 1000;
            retVal = cpq_service.GetQuoteData(credentials.Login, credentials.Password, cartCompositeNumber, revNumber);


            return retVal;
        }

        public static String SearchQuotes(Credentials credentials, String SearchCriteria)
        {
            string retVal = "";

        //http://help.webcomcpq.com/doku.php?id=appendixd:search_quotes
        // this method enables the external system to retrieve quotes from SAP CPQ based on provided search criteria. 
        //This method is only available if SAP CPQ user account that is used to make a call is set as an administrative account. 
        //The maximum number of quotes that can be returned is 2000. 

//        Examples:

//            DATE_MODIFIED > '8/3/2011 13:50:20'
//        Returns all quotes that have been modified after this date / time
//    DATE_CREATED > '9/24/2011 00:00:00'
//        Returns all quotes that have been created after this date / time
//    DATE_MODIFIED > '8/3/2011 13:50:20' AND ORDER_STATUS = '2'
//        Returns all quotes that have been modified after this date / time that are in status ‘Order Placed’

//If Criteria for search is empty, SAP CPQ will return all quotes(top 2000 quotes).

            CpqApi.CpqApi cpq_service = new CpqApi.CpqApi();
            cpq_service.Timeout = 200 * 1000;

            retVal = cpq_service.SearchQuotes(credentials.Login, credentials.Password, SearchCriteria);

            return retVal;


        }

        public static String ValidateCatalogueCodes(Credentials credentials, ValidateCatalogueCodes catalogueCodes)
        {
            //http://help.webcomcpq.com/doku.php?id=appendixd:validatecataloguecodeswebmethod:validatecataloguecodeswebmethod

            //  <CatalogueCodes>
            //< CatalogueCode > A2223A </ CatalogueCode >
            //< CatalogueCode > A2223B </ CatalogueCode >
            //< CatalogueCode > A2223C </ CatalogueCode >
            //</ CatalogueCodes >


            //http://help.webcomcpq.com/doku.php?id=appendixd:validatecataloguecodeswebmethod:validatecataloguecodeswebmethod

            //Function description: ValidateCatalogueCodes function executes reverse search on supplied part numbers.
            //    Result of this function is validity status for each supplied catalogue code.
            //    If code is valid, result will also contain product name and item list price.


            //API parameters username / password identifies the API user

            //Maximum number of Catalogue codes per one call is limited to 5 in order to obtain optimal function and system resources 
            //usability.



            string retVal = "";
            CpqApi.CpqApi cpq_service = new CpqApi.CpqApi();
            cpq_service.Timeout = 200 * 1000;
            XmlDocument xDoc = catalogueCodes.CreateXml();


            XmlNode response = cpq_service.ValidateCatalogueCodes(credentials.Login, credentials.Password, xDoc);
            retVal = response.InnerXml;
            Console.WriteLine("Validate Catalogue Codes response: " + retVal);

            return retVal;

        }

        public static String GetCartActions (Credentials credentials, String OrderID)
        {
            //gets the available actions for given quote and for supplied username, based on quote's status. 
            string retVal = "";

            CpqApi.CpqApi cpq_service = new CpqApi.CpqApi();
            cpq_service.Timeout = 200 * 1000;

            XmlNode response = cpq_service.getActionList(credentials.Login, credentials.Password, OrderID);
            retVal = response.InnerXml;
            Console.WriteLine("Get Cart Actions response: " + retVal);

            return retVal;
        }

        public static String GetCartProperties (Credentials credentials, String QuotationNumber)
        {
            string retVal = "";
            //returns values for specified cart properties. If no cart property is explicitly specified values of all properties will be returned. 
            //currently, response always returns all properties;
            CpqApi.CpqApi cpq_service = new CpqApi.CpqApi();
            cpq_service.Timeout = 200 * 1000;

            XmlNode response = cpq_service.getCartProperties(credentials.Login, credentials.Password, QuotationNumber, null);
            retVal = response.InnerXml;
            Console.WriteLine("Get Cart Properties response " + retVal);
            return retVal;
        }

        public static String GetQuoteItemsAttributes (Credentials credentials, String CartCompositeNumber)
        {
            string retVal = "";

            //returns attributes (all or specified ones) from desired quote
            //Important note: in XML, Line Items are stored in <PRODUCT> nodes, just like Main Items. They are not present in <ATTRIBUTE> node. Also, for Line Items,
            //following nodes are always empty: <ProductId>, <IsSimple>, <IsValid>, <DescriptionLong>

            CpqApi.CpqApi cpq_service = new CpqApi.CpqApi();
            cpq_service.Timeout = 200 * 1000;
            bool GetAllAttributes = true;
            string response = cpq_service.GetQuoteItemsAttributes(credentials.Login, credentials.Password, CartCompositeNumber, null, null, GetAllAttributes);
            retVal = response;
            Console.WriteLine("Get Quote Items Attributes response " + response);

            return retVal;
        }

        public static String GetAPIErrorDescription (string API_Error_Code)
        {

            //based on http://help.webcomcpq.com/doku.php?id=appendixd:apierrorcodes

            string retVal = "";
            string errorCode = API_Error_Code;

            //General API Error Codes:
            if (errorCode.Equals("100000"))
                retVal = "Unexpected exception";
            else if (errorCode.Equals("101001"))
                retVal = "Invalid login username/password supplied";

            //New Quote API
            else if (errorCode.Equals("100011"))
                retVal = "Invalid customer role supplied. Allowed range is from 1 to 3";
            else if (errorCode.Equals("100012"))
                retVal = "Attribute 'CustomerRoleType' is required for node customer";
            else if (errorCode.Equals("100013"))
                retVal = "First name is either not existing or is empty string, but it is a required field";
            else if (errorCode.Equals("100014"))
                retVal = "Last name is either not existing or is empty string, but it is a required field";
            else if (errorCode.Equals("100015"))
                retVal = "Address1 is a required field, and it is either not supplied or is empty";
            else if (errorCode.Equals("100016"))
                retVal = "City is a required field, and it is either not supplied or empty";
            else if (errorCode.Equals("100017"))
                retVal = "StateAbbrev is a required field, and it is either not supplied or empty";
            else if (errorCode.Equals("100018"))
                retVal = "Zip code is a required field, and You either did not supply it or left it empty";
            else if (errorCode.Equals("100019"))
                retVal = "CounrtyAbbrev is a required field and You either didn't supply it or left it empty";
            else if (errorCode.Equals("100020"))
                retVal = "EMail field is not supplied, or is supplied empty, and it is required";
            else if (errorCode.Equals("100022"))
                retVal = "Supplied owner username not found in CPQ database";
            else if (errorCode.Equals("100023"))
                retVal = "Invalid Market";
            else if (errorCode.Equals("100024"))
                retVal = "A minimum of {{requiredNumberOfCustomers}} customers needs to be supplied";
            else if (errorCode.Equals("100025"))
                retVal = "Supplied State AbbrevParameter Is Invalid";
            else if (errorCode.Equals("100026"))
                retVal = "Supplied CountryAbbrev parameter is invalid";
            else if (errorCode.Equals("100027"))
                retVal = "Supplied TerritoryName parameter is invalid";
            else if (errorCode.Equals("100028"))
                retVal = "Supplied email address is invalid";
            else if (errorCode.Equals("100029"))
                retVal = "Quote must have at least one item";
            else if (errorCode.Equals("100030"))
                retVal = "The item with catalogue code {{mi.PartNumber.Value}} does not exit";
            else if (errorCode.Equals("100031"))
                retVal = "Promo code {{apiCart.PromoCodes[0].CodeValue.Value}} is not a valid PromoCode";
            else if (errorCode.Equals("100032"))
                retVal = "Internal error";
            else if (errorCode.Equals("100043"))
                retVal = "You supplied an invalid string for customer ID";
            else if (errorCode.Equals("100044"))
                retVal = "Customer with supplied ID is not available";
            else if (errorCode.Equals("100045"))
                retVal = "Attribute name node is either not supplied or left blank";
            else if (errorCode.Equals("100046"))
                retVal = "At least one attribute value is required";
            else if (errorCode.Equals("100047"))
                retVal = "The name You supplied is not valid for the item";
            else if (errorCode.Equals("100048"))
                retVal = "You supplied an invalid value for attribute";
            else if (errorCode.Equals("100049"))
                retVal = "Customer with supplied External ID is not availabled";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100051"))
                retVal = "Mappings failed while downloading data from CRM";
            else if (errorCode.Equals("100053"))
                retVal = "Supplied quantity parameter must be greater than zero";
            else if (errorCode.Equals("100055"))
                retVal = "Cart property value not applicable";
            else if (errorCode.Equals("100056"))
                retVal = "You cannot create quotes with incomplete configurations";
            else if (errorCode.Equals("100057"))
                retVal = "Mappings failed while uploading data to CRM";
            else if (errorCode.Equals("API_NewQuote_ParameterMissing"))
                retVal = "All parameters not sent";
            else if (errorCode.Equals("API_NewQuote_UserNotMappedInCPQ"))
                retVal = "USER NOT MAPPED IN CPQ";
            else if (errorCode.Equals("API_NewQuote_ProductIsObsolete"))
                retVal = "You cannot add to quote the obsolete product";
            else if (errorCode.Equals("API_NewQuote_InvalidScparamDateFormat"))
                retVal = "Cart property value not applicable";
            //Users Administrations API
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            //Customers Administration API
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            //Custom Table Administration API
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            //Company Administration API
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            //Create New Quote And Get Quote Data API
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            //PriceBook Administration Through Custom Table API
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            //Salesforce API
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            //Cross Reference
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            //Microsoft CRM
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            //SAP CRM Api
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            else if (errorCode.Equals("100050"))
                retVal = "OpportunityId node is required";
            //Not Found
            else
                retVal = "Unrecognized Error Code, please double check and try again";


            return retVal;
        }
    }
}
