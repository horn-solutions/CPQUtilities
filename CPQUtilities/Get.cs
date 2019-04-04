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

        //public static Product GetProductByUSEnglishName(string name, Credentials credentials)
        //{
        //    Product retVal = null;

        //    //do stuff with server to get XML copy of product
        //    XmlDocument xdoc = new XmlDocument();



        //    retVal = Product.LoadFromXML(xdoc);
        //    return retVal;
        //}

        //public static Product GetProductByProductId(int productId, Credentials credentials)
        //{
        //    Product retVal = null;
        //    WsSrv.WsSrv service = new WsSrv.WsSrv();
        //    //wait 200 seconds:
        //    service.Timeout = 200 * 1000;




        //    return retVal;
        //}

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
    }
}
