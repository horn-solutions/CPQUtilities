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
        //not required:
        public string DisplayType { get; set; } //supports values: Simple, Configurable, System, Collection, Parent_child; default type is "Simple product"
        public bool SkipCategoriesOnProductUpdate { get; set; } //default value (if attribute is missing): false
        public bool SkipPermissionsOnProductUpdate { get; set; } //default value (if attribute is missing): false
        public string Identificator { get; set; } //default value (if node is missing): PartNumber
        public string ShippingCosts { get; set; } //Default Value (if node is missing): Empty
        public string Permissions { get; set; } //if permissions node is present in XML and is empty, product will not be visible to any permission group
        public string CPQProductId { get; set; } //when product is being created, this node is not required; if any value is sent through this node, it will be ignored
        public string PartNumber { get; set; } //Default Value(if node is missing): Empty
        public string UPC { get; set; } //Default value (if node is missing): Empty
        public string MPN { get; set; }
        public string ProductFamilyCode { get; set; }
        public string RecurringPriceFormula { get; set; }
        public string RecurringCostFormula { get; set; }
        public string Inventory { get; set; }
        public string LeadTime { get; set; }
        public string ProductVersion { get; set; }
        public string ExternalId { get; set; }
        public bool Active { get; set; }
        public bool IsSAPProduct { get; set; }
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
        public string LongDescription { get; set; }
        public string CartDescription { get; set; }
        public string Attributes { get; set; }
        public string AttributeType { get; set; }
        public string AttributeDisplayType { get; set; }
        public string AttributeMeasurementType { get; set; }
        public string AttributeRank { get; set; }
        public string AttributeLineItem { get; set; }
        public string AttributeLineItemDescription { get; set; }
        public string AttributeRankWithinCart { get; set; }
        public string AttributeSpansAcrossEntireRow { get; set; }
        public string AttributeRequired { get; set; }
        public string AttributeLabel { get; set; }
        public string AttributeHint { get; set; }
        public string AttributeShowOneTimePrice { get; set; }
        public string AttributeShowRecurringPrice { get; set; }
        public string AttributeButtonText { get; set; }
        public string AttributeAttachScriptButton { get; set; }
        public string AttributeButtonScriptsAttached { get; set; }
        public string AttributeButtonScript { get; set; }
        public string ButtonScriptAttachedRank { get; set; }
        public string AttributeValuesPreselected { get; set; }
        public string Tabs { get; set; }
        public string TabsSystemId { get; set; }
        public string TabsName { get; set; }
        public string TabsProductTabRank { get; set; }
        public string TabsLayoutTemplate { get; set; }
        public string TabsVisibilityPermission { get; set; }
        public string TabsVisibilityCondition { get; set; }
        public string TabsShowTabHeader { get; set; }
        public string TabsAttributes { get; set; }
        public string TabsAttributesName { get; set; }
        public string TabsAttributesRank { get; set; }
        public string GlobalScripts { get; set; }


        //required fields:
        public string ProductType { get; set; }
        public Translations ProductName { get; set; }
        public CategoryList Categories { set; get; }
        public string CategoryListString { get; set; }


        public Product()
        {
            //set defaults here
            //http://help.webcomcpq.com/doku.php?id=appendixd:simple_product_administration:input_xml_example
            Permissions = "Visible to all";
            SkipCategoriesOnProductUpdate = false;
            SkipPermissionsOnProductUpdate = false;
            Identificator = PartNumber;
            ShippingCosts = "";
            PartNumber = "";
            UPC = "";
            Active = true;
            IsSAPProduct = false;


        }

        public XmlDocument CreateXml()
        {
            //http://help.webcomcpq.com/doku.php?id=appendixd:simple_product_administration:input_xml_example

            XmlDocument retVal = new XmlDocument();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<Products SkipCategoriesOnProductUpdate='" + SkipCategoriesOnProductUpdate.ToString().ToLower() +"' SkipPermissionsOnProductUpdate='" + SkipPermissionsOnProductUpdate.ToString().ToLower() +"' >");
            sb.AppendLine("<Product>");
            sb.AppendLine("<Identificator>" + Identificator + "</Identificator>");
            sb.AppendLine("<DisplayType>" + DisplayType + "</DisplayType>");
            sb.AppendLine("<PartNumber>" + PartNumber + "</PartNumber>");
            sb.AppendLine("<ProductType>" + ProductType + "</ProductType>");
            sb.AppendLine("<ProductName><USEnglish><![CDATA[{" + ProductName + "}]]></USEnglish></ProductName>");
            sb.AppendLine("<StartDate>" + StartDate.ToString() + "</StartDate>");
            sb.AppendLine("<EndDate>" + EndDate.ToString() + "</EndDate>");
            sb.AppendLine("<Categories><USEnglish><![CDATA[{" + CategoryListString + "}]]></USEnglish></Categories>");
            sb.AppendLine("</Product>");
            sb.AppendLine("</Products>");


            retVal.LoadXml(sb.ToString());
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
