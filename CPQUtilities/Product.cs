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
        public string DisplayType { get; set; }
        public bool SkipCategoriesOnProductUpdate { get; set; }
        public bool SkipPermissionsOnProductUpdate { get; set; }
        public string Identifier { get; set; }
        public string ShippingCosts { get; set; }
        public string Permissions { get; set; } //if permissions node is present in XML and is empty, product will not be visible to any permission group
        public string CPQProductId { get; set; } //when product is being created, this node is not required; if any value is sent through this node, it will be ignored
        public string PartNumber { get; set; }
        public string UPC { get; set; }
        public string MPN { get; set; }
        public string ProductFamilyCode { get; set; }
        public string RecurringPriceFormula { get; set; }
        public string RecurringCostFormula { get; set; }
        public string Inventory { get; set; }
        public string LeadTime { get; set; }
        public string ProductVersion { get; set; }
        public string ExternalId { get; set; }
        public bool Active { get; set; }
        public string IsSAPProduct { get; set; }
        public string Weight { get; set; }
        public string Image { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UserCanEnterQuantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public string PricingMechanism { get; set; }
        public string PricingCode { get; set; }
        public string BaseRecurringPrice { get; set; }
        public string Price { get; set; }
        public string PriceFormual { get; set; }
        public string CostFormula { get; set; }
        public string Description { get; set; }
        //public string BaseRecurringPrice { get; set; }
        //public string BaseRecurringPrice { get; set; }
        //public string BaseRecurringPrice { get; set; }
        //public string BaseRecurringPrice { get; set; }
        //public string BaseRecurringPrice { get; set; }
        //public string BaseRecurringPrice { get; set; }
        //public string BaseRecurringPrice { get; set; }
        //public string BaseRecurringPrice { get; set; }
        //public string BaseRecurringPrice { get; set; }



        public string ProductType { get; set; }
        public Translations ProductName { get; set; }
        
        public CategoryList Categories { set; get; }

        public Product()
        {
            //set defaults here
            //http://help.webcomcpq.com/doku.php?id=appendixd:simple_product_administration:input_xml_example
            Permissions = "Visible to all";


        }

        public XmlDocument CreateXml()
        {
            //http://help.webcomcpq.com/doku.php?id=appendixd:simple_product_administration:input_xml_example

            XmlDocument retVal = new XmlDocument();

            //generate xml structure based on fields that are filled in
                          // XmlDocument xDoc = new XmlDocument();
            //                retVal.LoadXml(string.Format(@"
            //<Products>
            //    <Product>
            //        <Identificator>{0}</Identificator>
            //        <DisplayType>{1}</DisplayType>
            //        <PartNumber>{2}</PartNumber>
            //        <ProductType>{3}</ProductType>
            //        <ProductName>
            //            <USEnglish><![CDATA[{4}]]></USEnglish>
            //        </ProductName>
            //        <StartDate>{5}</StartDate>
            //        <EndDate>{6}</EndDate>
            //        <Categories>
            //            <USEnglish><![CDATA[{7}]]></USEnglish>
            //        </Categories>
            //    </Product>
            //</Products>
            //", ProductId, Identifier, DisplayType, PartNumber, ProductType, ProductName, StartDate, EndDate, Categories));

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
