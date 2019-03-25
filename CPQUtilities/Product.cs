using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CPQUtilities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Identifier { get; set; }
        public string DisplayType { get; set; }
        public string PartNumber { get; set; }
        public string ProductType { get; set; }
        public Translations ProductName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CategoryList Categories { set; get; }

        public Product()
        {
            //set defaults here

        }

        public XmlDocument CreateXml()
        {
            XmlDocument retVal = new XmlDocument();

            //generate xml structure based on fields that are filled in

            return retVal;
        }

        public static Product LoadFromXML(XmlDocument xdoc)
        {
            Product retVal = new Product();

            // read the xml into fields

            return retVal;
        }


    }
}
