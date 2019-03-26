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
        public ProductDisplayType DisplayType { get; set; } //supports values: Simple, Configurable, System, Collection, Parent_child; default type is "Simple product"
        public bool SkipCategoriesOnProductUpdate { get; set; } //default value (if attribute is missing): false
        public bool SkipPermissionsOnProductUpdate { get; set; } //default value (if attribute is missing): false
        public ProductIdentificator Identificator { get; set; } //default value (if node is missing): PartNumber
        public string ShippingCosts { get; set; } //Default Value (if node is missing): Empty
        public string Permissions { get; set; } //if permissions node is present in XML and is empty, product will not be visible to any permission group
        public string CPQProductId { get; set; } //when product is being created, this node is not required; if any value is sent through this node, it will be ignored
        public string PartNumber { get; set; } //Default Value(if node is missing): Empty
        public string UPC { get; set; } //Default value (if node is missing): Empty
        public string MPN { get; set; } //Default Value (if node is missing) : Empty
        public string ProductFamilyCode { get; set; } //Default Value (if node is missing) : Empty
        public string RecurringPriceFormula { get; set; } //Default Value (if node is missing) : Empty
        public string RecurringCostFormula { get; set; } //Default Value (if node is missing) : Empty
        public string Inventory { get; set; } //Default Value (if node is missing) : Empty
        public string LeadTime { get; set; } //Default Value (if node is missing) : Empty
        public string ProductVersion { get; set; } //Default Value (if node is missing) : 1
        public string ExternalId { get; set; } //Default Value (if node is missing) : Empty
        public bool Active { get; set; } //Default Value (if node is missing) : TRUE
        public string IsSAPProduct { get; set; } //Default Value (if node is missing) : FALSE
        public string Weight { get; set; } //Default Value (if node is missing) : Empty
        public string Image { get; set; } //Default Value (if node is missing) : Empty
        public DateTime? StartDate { get; set; } //Default Value (if node is missing) : Empty
        public DateTime? EndDate { get; set; } //Default Value (if node is missing) : Empty
        public string UserCanEnterQuantity { get; set; } //Default Value (if node is missing) : Empty
        public string UnitOfMeasure { get; set; } //Default Value (if node is missing) : Empty, a three character iso code
        public string PricingMechanism { get; set; } //Default Value (if node is missing) : Value of application parameter 'As default source for product and attribute price use' (found in Setup>Pricing/Calculations>Pricebooks)
        public string PricingCode { get; set; } //Default Value (if node is missing) : Empty
        public string BaseRecurringPrice { get; set; } //Default Value (if node is missing) : Empty
        public string Price { get; set; } //Default Value (if node is missing) : Empty
        public string PriceFormual { get; set; } //Default Value (if node is missing) : Empty
        public string CostFormula { get; set; } //Default Value (if node is missing) : Empty
        public string Description { get; set; } //Default Value (if node is missing) : Empty
        public string LongDescription { get; set; } //Default Value (if node is missing) : Empty
        public string CartDescription { get; set; } //Default Value (if node is missing) : Empty
        public string Attributes { get; set; } //Default Value (if node is missing) : Empty
        public string AttributeType { get; set; } //Default Value (if node is missing) : "UserSelection"; Supported values: “UserSelection”,”Date”,”String”,”Number”,”Att.Quantity”,”AttValue.Quantity”,”ExternalValue”,”UnitsOfMeasurement”,”Container”
        public string AttributeDisplayType { get; set; } //Default Value (if node is missing) : DropDown; Attribute Display type Custom control is not supported on API call; Attribute type Container cannot be created over API call;
        public string AttributeMeasurementType { get; set; } //This node is required if Attribute type is UnitsOfMeasurement 
        public int AttributeRank { get; set; } //This node is optional. If node is not present or it is empty, system will assign rank value in order the values are sent: 10, 20, 30…
        public string AttributeLineItem { get; set; } //Supported values: 1 for Yes, 0 for No.
        public string AttributeLineItemDescription { get; set; } //optional; can be translated similar to Product name
        public int AttributeRankWithinCart { get; set; } //optional; can be set only if "Line item flag" has value 1
        public string AttributeSpansAcrossEntireRow { get; set; } //optional; not supported for "Button"; supported values: "1" as True. "0" value is sent in case this flag should be deselected
        public string AttributeRequired { get; set; } //optional; not supported for "Button"; supported values: "1" as True. "0" value is sent in case this flag should be deselected
        public string AttributeLabel { get; set; } //optional; can be translated to Any Language
        public string AttributeHint { get; set; } //optional; can be translated to Any Language
        public string AttributeShowOneTimePrice { get; set; } //optional; not supported for "Button"; supported values: "1" as True. "0" value is sent in case this flag should be deselected
        public string AttributeShowRecurringPrice { get; set; } //optional; not supported for "Button"; supported values: "1" as True. "0" value is sent in case this flag should be deselected
        public string AttributeButtonText { get; set; } //plain text or CPQ formula;
        public string AttributeAttachScriptButton { get; set; } //optional; only supported for "Button"; supported values: "1" as True. "0" value is sent in case this flag should be deselected
        public string AttributeButtonScriptsAttached { get; set; } //This node will support adding child nodes <ButtonScript> and <Rank>
        public string AttributeButtonScript { get; set; } //CPQ does not support adding new script over API call. Product administration API can only add a script that already exists within CPQ
        public string ButtonScriptAttachedRank { get; set; } //rank
        public string AttributeValuesPreselected { get; set; } //optional
        public string Tabs { get; set; } //optional; not allowed with Simple Products;
        public string TabsSystemId { get; set; } //optional; not allowed with Simple Products;
        public string TabsName { get; set; } //optional; not allowed with Simple Products;
        public string TabsProductTabRank { get; set; } //optional; not allowed with Simple Products;
        public string TabsLayoutTemplate { get; set; } //optional; not allowed with Simple Products;
        public string TabsVisibilityPermission { get; set; } //optional; not allowed with Simple Products;
        public string TabsVisibilityCondition { get; set; } //optional; not allowed with Simple Products;
        public string TabsShowTabHeader { get; set; } //optional; not allowed with Simple Products;
        public string TabsAttributes { get; set; } //optional; not allowed with Simple Products;
        public string TabsAttributesName { get; set; } //optional; not allowed with Simple Products;
        public string TabsAttributesRank { get; set; } //optional; not allowed with Simple Products;
        public string GlobalScripts { get; set; } //optional; not supported for displaytype button
        public string GlobalScriptsName { get; set; } //child node for GlobalScripts
        public string GlobalScriptsRank { get; set; } //child node for GlobalScripts
        public string GlobalScriptsEvents { get; set; } //child node for GlobalScripts
        public ProductGlobalScriptsEventsEvent GlobalScriptsEventsEvent { get; set; } //child node for GlobalScripts; Supported values: OnProductLoaded, OnProductRuleExecutionStart, OnProductRuleExecutionEnd, OnProductTabChanged, OnProductCompleted, OnProductAddedToQuote, OnProductBeforeAddToQuote


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
            Identificator = ProductIdentificator.PartNumber;
            Permissions = "Visible to all";
        }

        private bool IsValid()
        {
            bool retVal = true;

            retVal = retVal && ProductName != null && ProductName.Count > 0;
            retVal = retVal && Categories != null && Categories.Count > 0;
            retVal = retVal && !string.IsNullOrEmpty(ProductType);

            return retVal;
        }

        public XmlDocument CreateXml()
        {
            if (!IsValid())
                throw new Exception("Product Is not valid, XML will not be created");


            //http://help.webcomcpq.com/doku.php?id=appendixd:simple_product_administration:input_xml_example

            XmlDocument retVal = new XmlDocument();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<Products SkipCategoriesOnProductUpdate='" + SkipCategoriesOnProductUpdate.ToString().ToLower() + "' SkipPermissionsOnProductUpdate='" + SkipPermissionsOnProductUpdate.ToString().ToLower() + "' >");
            sb.AppendLine("<Product>");
            sb.AppendLine("<Identificator>" + Enum.GetName(typeof(ProductIdentificator), Identificator) + "</Identificator>");
            sb.AppendLine("<DisplayType>" + Enum.GetName(typeof(ProductDisplayType), DisplayType) + "</DisplayType>");

            sb.AppendLine("<ProductName>");
            sb.AppendLine(ProductName.ToXML());
            sb.AppendLine("</ProductName>");

            sb.AppendLine("<PartNumber>" + PartNumber + "</PartNumber>");
            sb.AppendLine("<ProductType>" + ProductType + "</ProductType>");

            if (StartDate.HasValue) sb.AppendLine("<StartDate>" + StartDate.Value.ToString("M/d/yyyy") + "</StartDate>");
            if (EndDate.HasValue) sb.AppendLine("<EndDate>" + EndDate.Value.ToString("M/d/yyyy") + "</EndDate>");

            sb.AppendLine("<Categories>");
            sb.AppendLine(Categories.ToXML());
            sb.AppendLine("</Categories>");


            sb.AppendLine("</Product>");
            sb.AppendLine("</Products>");


            retVal.LoadXml(sb.ToString());
            return retVal;
        }

        //private void CheckAndAdd(StringBuilder stringBuilder, string nodeName, object value)
        //{
        //    if (value == null) return;

        //    switch (value.GetType().Name)
        //    {
        //        case "string":
        //            if (string.IsNullOrEmpty((string)value))
        //                return;
        //            else
        //                stringBuilder.AppendLine(string.Format("<{0}><![CDATA[{{{1}}}]]></{0}>", value));
        //            break;

        //        default:
        //            break;
        //    }
        //}

        public static Product LoadFromXML(XmlDocument xdoc)
        {
            Product retVal = new Product();

            // read the xml into fields

            return retVal;
        }


    }
}
