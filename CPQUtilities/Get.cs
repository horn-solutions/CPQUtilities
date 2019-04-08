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

            //returns general quote data (including main/line items), actions, key attributes, product types, promo codes, additional discounts, markets, shippings, customer data and customer fields

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
    }
}
