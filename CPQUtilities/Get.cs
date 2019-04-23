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
            else if (errorCode.Equals("103002"))
                retVal = "Approving parent user not found in CPQ database";
            else if (errorCode.Equals("103003"))
                retVal = "Ordering parent user not found in CPQ database";
            else if (errorCode.Equals("103004"))
                retVal = "Managing parent user not found in CPQ database";
            else if (errorCode.Equals("103005"))
                retVal = "Password cannot be blank";
            else if (errorCode.Equals("103006"))
                retVal = "First name cannot be blank";
            else if (errorCode.Equals("103007"))
                retVal = "User type cannot be blank";
            else if (errorCode.Equals("103008"))
                retVal = "Supplied user type is unknown in CPQ";
            else if (errorCode.Equals("103009"))
                retVal = "User's country cannot be blank";
            else if (errorCode.Equals("103010"))
                retVal = "Company code not found in CPQ";
            else if (errorCode.Equals("103011"))
                retVal = "Company with company code {{companyCode}} does not exist, and cannot be updated";
            else if (errorCode.Equals("103014"))
                retVal = "User with username {{username}} does not exist, and cannot be updated";
            else if (errorCode.Equals("103018"))
                retVal = "Node {{nodeName}} is required";
            else if (errorCode.Equals("103019"))
                retVal = "Can not convert value of {{nodeName}} : {{innerText}} to boolean";
            else if (errorCode.Equals("103020"))
                retVal = "Country {{Country}} does not exist";
            else if (errorCode.Equals("103021"))
                retVal = "Brand for provided brand name not found";
            else if (errorCode.Equals("103022"))
                retVal = "Custom field not recognized";
            else if (errorCode.Equals("103023"))
                retVal = "User with username {{username}} already exists, and cannot be added";
            else if (errorCode.Equals("103025"))
                retVal = "Node {{nodeName}} has invalid attribute value";
            //Customers Administration API
            else if (errorCode.Equals("104003"))
                retVal = "Customer delete failed";
            else if (errorCode.Equals("104004"))
                retVal = "Saving customer failed";
            else if (errorCode.Equals("104005"))
                retVal = "Found {{number}} cutomers";
            else if (errorCode.Equals("104006"))
                retVal = "Invalid territory name";
            else if (errorCode.Equals("104007"))
                retVal = "Invalid country or state";
            else if (errorCode.Equals("104008"))
                retVal = "Deserialization failed";
            else if (errorCode.Equals("104009"))
                retVal = "Unknown owner username";
            else if (errorCode.Equals("104010"))
                retVal = "Invalid OwnerID";
            else if (errorCode.Equals("104011"))
                retVal = "No Customers Provided";
            else if (errorCode.Equals("104012"))
                retVal = "Unknown action";
            else if (errorCode.Equals("104013"))
                retVal = "You shouldn't provide ID element when adding new cutomer";
            else if (errorCode.Equals("104014"))
                retVal = "Specified Custom Field doesn’t exist in the system";
            //Custom Table Administration API
            else if (errorCode.Equals("105001"))
                retVal = "Invalid table name";
            else if (errorCode.Equals("105002"))
                retVal = "Invalid action";
            else if (errorCode.Equals("105003"))
                retVal = "column is necessery for this action";
            else if (errorCode.Equals("105004"))
                retVal = "Number of provided rows must be between 1 and defined limit";
            else if (errorCode.Equals("105005"))
                retVal = "Column missing or invalid column name";
            else if (errorCode.Equals("105007"))
                retVal = "column is not allowed for this action";
            else if (errorCode.Equals("105009"))
                retVal = "No entries found for provided SearchCriteria";
            else if (errorCode.Equals("105010"))
                retVal = "Missing column for update";
            else if (errorCode.Equals("105012"))
                retVal = "Colum names muste be unique";
            else if (errorCode.Equals("105013"))
                retVal = "Number of values doesn't match the number of columns provided";
            //Company Administration API
            else if (errorCode.Equals("106001"))
                retVal = "Company name is a required field";
            else if (errorCode.Equals("106002"))
                retVal = "Required node COMPANYCODE not supplied";
            else if (errorCode.Equals("106003"))
                retVal = "Node value {{nodeValue}} is too big. Max size is {{maxSize}}";
            else if (errorCode.Equals("106004"))
                retVal = "Node value {{nodeValue}} is not in the right format";
            else if (errorCode.Equals("106005"))
                retVal = "  .";
            //Create New Quote And Get Quote Data API
            else if (errorCode.Equals("107001"))
                retVal = "ProductName is a required parameter";
            else if (errorCode.Equals("107002"))
                retVal = "Invalid ProductName";
            //PriceBook Administration Through Custom Table API
            else if (errorCode.Equals("108001"))
                retVal = "Provided date is not valid";
            else if (errorCode.Equals("108002"))
                retVal = "Provided price is not valid";
            //Salesforce API
            else if (errorCode.Equals("SF_ParamMissing_SessionId"))
                retVal = "Login Data is incorrect. Please contact your SalesForce administrator";
            else if (errorCode.Equals("SF_ParamMissing_Url"))
                retVal = "Login Data is incorrect. Please contact your SalesForce administrator";
            else if (errorCode.Equals("SF_ParamMissing_Pass"))
                retVal = "Login Data is incorrect. Please contact your SalesForce administrator";
            else if (errorCode.Equals("SF_ParamUncorrect_Pass"))
                retVal = "Login Data is incorrect. Please contact your SalesForce administrator";
            else if (errorCode.Equals("SF_DomainUncorrect"))
                retVal = "Domain that Salesforce provided does not exist in CPQ. Please contact your SalesForce administrator";
            else if (errorCode.Equals("SF_NoCRMAdminAccount"))
                retVal = "Administrative Salesforce account is not set up. Please contact your CPQ administrator";
            else if (errorCode.Equals("SF_LoginUnsuccessfulWithCRMAdminAccount"))
                retVal = "Logging into Salesforce with administrative Salesforce account failed. Please contact your CPQ administrator";
            else if (errorCode.Equals("SF_LoginUnsuccessfulWithProvidedSessionIdAndUrl"))
                retVal = "Logging into Salesforce with provided parameters failed. Please contact your CPQ or Salesforce administrator";
            else if (errorCode.Equals("SF_ErrorInQuery"))
                retVal = "There has been an error in query made to Salesforce";
            else if (errorCode.Equals("SF_ErrorInRetrieve"))
                retVal = "There has been an error in query made to Salesforce";
            else if (errorCode.Equals("SF_ErrorInDescribe"))
                retVal = "There has been an error in query made to Salesforce";
            else if (errorCode.Equals("SF_ErrorMalFormedQuery"))
                retVal = "There has been an error in query made to Salesforce";
            else if (errorCode.Equals("SF_ErrorMalFormedRetrieve"))
                retVal = "There has been an error in query made to Salesforce";
            else if (errorCode.Equals("SF_ErrorQueryIdDoesNotExist"))
                retVal = "There has been an error in query made to Salesforce";
            else if (errorCode.Equals("SF_ErrorQueryIsNotValid"))
                retVal = "There has been an error in query made to Salesforce";
            else if (errorCode.Equals("SF_ObjectNotQueriable"))
                retVal = "There has been an error in query made to Salesforce";
            else if (errorCode.Equals("SF_ObjectNotRetrievable"))
                retVal = "There has been an error in query made to Salesforce";
            else if (errorCode.Equals("SF_ObjectNotCreatable"))
                retVal = "There has been an error in query made to Salesforce";
            else if (errorCode.Equals("SF_ObjectNotUpdatable"))
                retVal = "There has been an error in query made to Salesforce";
            else if (errorCode.Equals("SF_ObjectNotDeletable"))
                retVal = "There has been an error in query made to Salesforce";
            else if (errorCode.Equals("SF_CrUpdOpp_RoleMissingForOppAccount"))
                retVal = "Opportunity cannot be created because the customer role that is used for creating Opportunity Account is emptyd";
            else if (errorCode.Equals("SF_CrUpdOpp_AccountIdNotProvided"))
                retVal = "Opportunity cannot be created because the Account Id of the customer role that is used for creating Opportunity Account is empty";
            else if (errorCode.Equals("SF_CrUpdOpp_StdPriceBookNotDefined"))
                retVal = "Standard Price book is not defined in Salesforce. Please contact your Salesforce administrator";
            else if (errorCode.Equals("SF_ObjectNotQueriable"))
                retVal = "There has been an error in query made to Salesforce";
            else if (errorCode.Equals("SF_ObjectNotRetrievable"))
                retVal = "There has been an error in query made to Salesforce";
            else if (errorCode.Equals("SF_CrUpdOpp_OppNotCreated"))
                retVal = "There was en error while creating new opportunity";
            else if (errorCode.Equals("SF_CrUpdOpp_OppNotUpdated"))
                retVal = "There was an error while updating opportunity";
            else if (errorCode.Equals("SF_CrUpdOpp_CreatingOppLineItems"))
                retVal = "There was an error while creating opportunity line items";
            else if (errorCode.Equals("SF_CrUpdOpp_NoPartNumberForProduct"))
                retVal = "Item # {{item_number}} was not added to the opportunity because it does not have part number";
            else if (errorCode.Equals("SF_CustRoles_CreatingAccCont"))
                retVal = "There was an error while creating/updating accounts and contacts in Salesforce from CPQ customer roles";
            else if (errorCode.Equals("SF_CartNotLoaded"))
                retVal = "Cart has not been loaded. Please select a cart";
            else if (errorCode.Equals("SF_SalesForceNotSelected"))
                retVal = "CPQ has not been set up to be integrated with Salesforce. Please contact your CPQ administrator";
            else if (errorCode.Equals("SF_CreateSfQuote"))
                retVal = "An error happened when attached quote informations were populated in Salesforce";
            else if (errorCode.Equals("SF_NoCRMItemMappinsDefined"))
                retVal = "There are no mappings defined for SF_Product2 and OpportunityLineItem in Admin ⇒ Setup⇒ CRM Integration Sutup ⇒ CRM Item Mappings";
            else if (errorCode.Equals("SF_NoIdentifingCRMItemMappingDefined"))
                retVal = "None of mappings defined in Admin ⇒ Setup⇒ CRM Integration Sutup ⇒ CRM Item Mappings has value true in the Identifing Product column";
            else if (errorCode.Equals("SF_FieldTooLong"))
                retVal = "Filed size of a field: {{fieldName}} is too long";
            else if (errorCode.Equals("SF_UnableToCastField"))
                retVal = "Field : {{fieldName}} can not be converted to number";
            else if (errorCode.Equals("LX_LoadingConfiguration"))
                retVal = "Error loading configuration";
            
            //Cross Reference
            else if (errorCode.Equals("CR_ProductNotFound"))
                retVal = "The part number is {{param}} . Product that matches the part number you inserted could not be found";
            else if (errorCode.Equals("CR_ProductFoundNoCrossRef"))
                retVal = "Competition product ' {{param}} ' matches the code you inserted , but it is not referenced to any home product";
            else if (errorCode.Equals("CR_ProductFoundNoConditition"))
                retVal = "Competition product ' {{param}} ' matches the code you inserted , but it can not be referenced to any home product because a condition is not met";
            else if (errorCode.Equals("CR_ProductFoundHeaderMessage"))
                retVal = "For the part number ' {{param1}} ' , ' {{param2}} ' , reference is made to home product ' {{param3}} '";
            else if (errorCode.Equals("CR_AttrValueRefNotFound"))
                retVal = "Reference for competition's attribute ' {{params1}} ' with attribute value ' {{params2}} ' could not be found";
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
