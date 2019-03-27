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

        public static Product GetProductByUSEnglishName(string name, Credentials credentials)
        {
            Product retVal = null;

            //do stuff with server to get XML copy of product
            XmlDocument xdoc = new XmlDocument();



            retVal = Product.LoadFromXML(xdoc);
            return retVal;
        }

        public static Product GetProductByProductId(int productId, Credentials credentials)
        {
            Product retVal = null;
            WsSrv.WsSrv service = new WsSrv.WsSrv();
            //wait 200 seconds:
            service.Timeout = 200 * 1000;

            


            return retVal;
        }
    }
}
