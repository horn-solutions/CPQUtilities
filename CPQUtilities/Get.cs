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

        

        public static String Catalogue(Credentials credentials)
        {
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

            //returns general quote data (including main/line items), actions, key attributes, product types, promo codes, additional discounts, markets, shippings, customer data and customer fields

            string retVal = "";

            CpqApi.CpqApi cpq_service = new CpqApi.CpqApi();
            cpq_service.Timeout = 200 * 1000;
            retVal = cpq_service.GetQuoteData(credentials.Login, credentials.Password, cartCompositeNumber, revNumber);


            return retVal;
        }
    }
}
