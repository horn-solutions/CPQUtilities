using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CPQUtilities
{
    //minimal XML used to create a product (product name, type and category are required nodes)
//    <Products>
//  <Product>  
//    <ProductType>Cardio</ProductType>
//    <ProductName>
//      <USEnglish><![CDATA[Step Excite+ 500]]></USEnglish>
//    </ProductName>
//    <Categories>
//      <USEnglish><![CDATA[Cardio>Excite+ Class]]></USEnglish>
//    </Categories>
//  </Product>
//</Products>


//overall example pulled from API site:
//<Products SkipCategoriesOnProductUpdate = "false" SkipPermissionsOnProductUpdate="false" >
//  <Product>
//    <Identificator>PartNumber</Identificator>
//    <ShippingCosts>
//      <ShippingName_1><![CDATA[some formula]]></ShippingName_1>
//      <ShippingName_2><![CDATA[some formula]]></ShippingName_2>
//    </ShippingCosts>
//    <Permissions>Sales;Sales Management</Permissions>
//    <CPQProductID><![CDATA[some_product_id]]></CPQProductID>
//    <PartNumber>DA353LNAL00</PartNumber>
//    <UPC><![CDATA[some_upc_num]]></UPC>
//    <MPN><![CDATA[some_mpn_num]]></MPN>
//    <ProductFamilyCode><![CDATA[some_prod_fam_code]]></ProductFamilyCode>
//    <RecurringPriceFormula><![CDATA[some_rec_price_formula]]></RecurringPriceFormula>
//    <RecurringCostFormula><![CDATA[some_rec_cost_formula]]></RecurringCostFormula>
//    <Inventory>1234</Inventory>
//    <LeadTime><![CDATA[3 weeks]]></LeadTime>
//    <ProductVersion><![CDATA[pv12]]></ProductVersion>
//    <ExternalId><![CDATA[some_ext_id]]></ExternalId>
//    <Active>true</Active>
//    <Weight>136.00</Weight>
//    <Image><![CDATA[image.jpg]]></Image>
//    <StartDate>1/31/2010</StartDate>
//    <EndDate>1/31/2011</EndDate>
//    <UserCanEnterQuantity>1</UserCanEnterQuantity>
//    <PricingMechanism>Custom Pricing</PricingMechanism>
//    <PricingCode><![CDATA[some pricing code]]></PricingCode>
//    <BaseRecurringPrice>1234</BaseRecurringPrice>
//    <Price>1234.45</Price>
//    <LongDescription>Some long description here</LongDescription>
//    <PriceFormula><![CDATA[136]]></PriceFormula>
//    <CostFormula><![CDATA[136]]></CostFormula>
//    <ProductType>Cardio</ProductType>
//    <ProductName>
//      <USEnglish><![CDATA[Step Excite+ 500]]></USEnglish>
//      <French><![CDATA[Step Excite+ 500]]></French>
//    </ProductName>
//    <Description>
//      <USEnglish><![CDATA[description english]]></USEnglish>
//      <French><![CDATA[description French]]></French>
//    </Description>
//    <CartDescription>
//      <USEnglish><![CDATA[cart description english]]></USEnglish>
//      <French><![CDATA[cart description French]]></French>
//    </CartDescription>
//    <Categories>
//      <USEnglish><![CDATA[Cardio>Excite+ Class]]></USEnglish>
//      <French><![CDATA[Cardios>Excites+ Class]]></French>
//    </Categories>
//    <Attributes>
//      <Attribute>
//        <AttributeName>
//          <USEnglish><![CDATA[LINE]]></USEnglish>
//          <French><![CDATA[LINEA]]></French>
//        </AttributeName>
//        <Values>
//          <Value>
//            <USEnglish><![CDATA[Excite+]]></USEnglish>
//            <French><![CDATA[Excite+]]></French>
//          </Value>
//        </Values>
//      </Attribute>
//      <Attribute>
//        <AttributeName>
//          <USEnglish><![CDATA[MODEL]]></USEnglish>
//          <French><![CDATA[MODELLO]]></French>
//        </AttributeName>
//        <Values>
//          <Value>
//            <USEnglish><![CDATA[Step]]></USEnglish>
//            <French><![CDATA[Step]]></French>
//          </Value>
//        </Values>
//      </Attribute>
//      <Attribute>
//        <AttributeName>
//          <USEnglish><![CDATA[VERSION]]></USEnglish>
//          <French><![CDATA[VERSIONE]]></French>
//        </AttributeName>
//        <Values>
//          <Value>
//            <USEnglish><![CDATA[500]]></USEnglish>
//            <French><![CDATA[500]]></French>
//          </Value>
//        </Values>
//      </Attribute>
//      <Attribute>
//        <AttributeName>
//          <USEnglish><![CDATA[FRAME]]></USEnglish>
//          <French><![CDATA[TELAIO]]></French>
//        </AttributeName>
//        <Values>
//          <Value>
//            <USEnglish><![CDATA[Grey]]></USEnglish>
//            <French><![CDATA[Argento]]></French>
//          </Value>
//        </Values>
//      </Attribute>
//    </Attributes>
//  </Product>
//</Products>

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
        public string PriceFormula { get; set; } //Default Value (if node is missing) : Empty
        public string CostFormula { get; set; } //Default Value (if node is missing) : Empty
        public string Description { get; set; } //Default Value (if node is missing) : Empty
        public string LongDescription { get; set; } //Default Value (if node is missing) : Empty
        public string CartDescription { get; set; } //Default Value (if node is missing) : Empty

        public string AttributeName { get; set; } //Default Value (if node is missing) : Empty
        public string AttributeType { get; set; } //Default Value (if node is missing) : "UserSelection"; Supported values: “UserSelection”,”Date”,”String”,”Number”,”Att.Quantity”,”AttValue.Quantity”,”ExternalValue”,”UnitsOfMeasurement”,”Container”
        public ProductAttributeDisplayType AttributeDisplayType { get; set; } //Default Value (if node is missing) : DropDown; Attribute Display type Custom control is not supported on API call; Attribute type Container cannot be created over API call;  
        public string AttributeMeasurementType { get; set; } //This node is required if Attribute type is UnitsOfMeasurement 
        public int AttributeRank { get; set; } //This node is optional. If node is not present or it is empty, system will assign rank value in order the values are sent: 10, 20, 30…
        public string AttributeLineItem { get; set; } //Supported values: 1 for Yes, 0 for No.
        public string AttributeLineItemDescription { get; set; } //optional; can be translated similar to Product name
        public int AttributeRankWithinCart { get; set; } //optional; can be set only if "Line item flag" has value 1
        public string AttributeSpansAcrossEntireRow { get; set; } //optional; not supported for "Button"; supported values: "1" as True. "0" value is sent in case this flag should be deselected
        public int AttributeRequired { get; set; } //optional; not supported for "Button"; supported values: "1" as True. "0" value is sent in case this flag should be deselected
        public string AttributeLabel { get; set; } //optional; can be translated to Any Language
        public string AttributeHint { get; set; } //optional; can be translated to Any Language
        public int AttributeShowOneTimePrice { get; set; } //optional; not supported for "Button"; supported values: "1" as True. "0" value is sent in case this flag should be deselected
        public int AttributeShowRecurringPrice { get; set; } //optional; not supported for "Button"; supported values: "1" as True. "0" value is sent in case this flag should be deselected
        public string AttributeButtonText { get; set; } //plain text or CPQ formula;
        public int AttributeAttachScriptButton { get; set; } //optional; only supported for "Button"; supported values: "1" as True. "0" value is sent in case this flag should be deselected
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
        //public string CategoryListString { get; set; }


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

            XmlNode userProducts = retVal.CreateElement("PRODUCTS");
            retVal.AppendChild(userProducts);

            ////These are attributes of Products, still WIP:////
            XmlAttribute scopu = retVal.CreateAttribute("SKIPCATEGORIESONPRODUCTUPDATE");
            scopu.InnerText = SkipCategoriesOnProductUpdate.ToString().ToUpper();
            userProducts.Attributes.Append(scopu);
            XmlAttribute spopu = retVal.CreateAttribute("SkipPermissionsOnProductUpdate");
            scopu.InnerText = SkipPermissionsOnProductUpdate.ToString().ToUpper();
            userProducts.Attributes.Append(spopu);


            //Product Tag: <PRODUCTS><PRODUCT>
            XmlNode userProduct = retVal.CreateElement("PRODUCT");
            userProducts.AppendChild(userProduct);

            Utility.AddIfNotEmptyOrNull(userProduct, "IDENTIFICATOR", Identificator);
            Utility.AddIfNotEmptyOrNull(userProduct, "DISPLAYTYPE", DisplayType);
            Utility.AddIfNotEmptyOrNull(userProduct, "PRODUCTNAME", ProductName);
            Utility.AddIfNotEmptyOrNull(userProduct, "PARTNUMBER", PartNumber);
            Utility.AddIfNotEmptyOrNull(userProduct, "PRODUCTType", ProductType);

            if (StartDate.HasValue)
            {
                Utility.AddIfNotEmptyOrNull(userProduct, "STARTDATE", StartDate);
            }

            if (EndDate.HasValue)
            {
                Utility.AddIfNotEmptyOrNull(userProduct, "ENDDATE", EndDate);
            }

            Utility.AddIfNotEmptyOrNull(userProduct, "CATEGORIES", Categories.ToString());


            Utility.AddIfNotEmptyOrNull(userProduct, "ShippingCosts", ShippingCosts);
            Utility.AddIfNotEmptyOrNull(userProduct, "Permissions", Permissions);
            Utility.AddIfNotEmptyOrNull(userProduct, "CPQProductId", CPQProductId);
            Utility.AddIfNotEmptyOrNull(userProduct, "UPC", UPC);
            Utility.AddIfNotEmptyOrNull(userProduct, "MPN", MPN);
            Utility.AddIfNotEmptyOrNull(userProduct, "ProductFamilyCode", ProductFamilyCode);
            Utility.AddIfNotEmptyOrNull(userProduct, "RecurringPriceFormula", RecurringPriceFormula);
            Utility.AddIfNotEmptyOrNull(userProduct, "RecurringCostFormula", RecurringCostFormula);
            Utility.AddIfNotEmptyOrNull(userProduct, "Inventory", Inventory);
            Utility.AddIfNotEmptyOrNull(userProduct, "LeadTime", LeadTime);
            Utility.AddIfNotEmptyOrNull(userProduct, "ProductVersion", ProductVersion);
            Utility.AddIfNotEmptyOrNull(userProduct, "ExternalId", ExternalId);
            Utility.AddIfNotEmptyOrNull(userProduct, "Active", Active);
            Utility.AddIfNotEmptyOrNull(userProduct, "IsSAPProduct", IsSAPProduct);
            Utility.AddIfNotEmptyOrNull(userProduct, "Weight", Weight);
            Utility.AddIfNotEmptyOrNull(userProduct, "Image", Image);
            Utility.AddIfNotEmptyOrNull(userProduct, "UserCanEnterQuantity", UserCanEnterQuantity);
            Utility.AddIfNotEmptyOrNull(userProduct, "UnitOfMeasure", UnitOfMeasure);
            Utility.AddIfNotEmptyOrNull(userProduct, "PricingMechanism", PricingMechanism);
            Utility.AddIfNotEmptyOrNull(userProduct, "PricingCode", PricingCode);
            Utility.AddIfNotEmptyOrNull(userProduct, "BaseRecurringPrice", BaseRecurringPrice);
            Utility.AddIfNotEmptyOrNull(userProduct, "Price", Price);
            Utility.AddIfNotEmptyOrNull(userProduct, "PriceFormula", PriceFormula);
            Utility.AddIfNotEmptyOrNull(userProduct, "CostFormula", CostFormula);
            Utility.AddIfNotEmptyOrNull(userProduct, "Description", Description);
            Utility.AddIfNotEmptyOrNull(userProduct, "LongDescription", LongDescription);
            Utility.AddIfNotEmptyOrNull(userProduct, "CartDescription", CartDescription);


            //The Attribute Input Parameters conflict with Input XML Examples. Some Parameters show up in Examples that are not part of the Input Parameters list. 
            //see: http://help.webcomcpq.com/doku.php?id=appendixd:simple_product_administration:input_xml_example vs http://help.webcomcpq.com/doku.php?id=appendixd:simple_product_administration:product_admin_webmethod_inputxml

            //Attributes is a parent container, nested within Products, that may contain additional child products; need to rethink this one:
            //XmlNode userAttributes = Utility.AddIfNotEmptyOrNull(userProducts, "Attributes", Attributes); 
            ////Attribute Child nodes, still WIP:////
            //Utility.AddIfNotEmptyOrNull(userAttributes, "Type", AttributeType);
            //Utility.AddIfNotEmptyOrNull(userAttributes, "DisplayType", AttributeDisplayType);
            //Utility.AddIfNotEmptyOrNull(userAttributes, "MeasurementType", AttributeMeasurementType);
            //Utility.AddIfNotEmptyOrNull(userAttributes, "Rank", AttributeRank);
            //Utility.AddIfNotEmptyOrNull(userAttributes, "LineItem", AttributeLineItem);
            //Utility.AddIfNotEmptyOrNull(userAttributes, "LineItemDescription", AttributeLineItemDescription);
            //Utility.AddIfNotEmptyOrNull(userAttributes, "RankWithinCart", AttributeRankWithinCart);
            //Utility.AddIfNotEmptyOrNull(userAttributes, "SpansAcrossEntireRow", AttributeSpansAcrossEntireRow);
            //Utility.AddIfNotEmptyOrNull(userAttributes, "Required", AttributeRequired);
            //Utility.AddIfNotEmptyOrNull(userAttributes, "Label", AttributeLabel);
            //Utility.AddIfNotEmptyOrNull(userAttributes, "Hint", AttributeHint);
            //Utility.AddIfNotEmptyOrNull(userAttributes, "ShowOneTimePrice", AttributeShowOneTimePrice);
            //Utility.AddIfNotEmptyOrNull(userAttributes, "ShowRecurringPrice", AttributeShowRecurringPrice);
            //Utility.AddIfNotEmptyOrNull(userAttributes, "ButtonText", AttributeButtonText);
            //Utility.AddIfNotEmptyOrNull(userAttributes, "AttachScriptButton", AttributeAttachScriptButton);
            //Utility.AddIfNotEmptyOrNull(userAttributes, "ValuesPreselected", AttributeValuesPreselected);

            //Buttons is child of Attributes; 
            //Utility.AddIfNotEmptyOrNull(userAttributes, "ButtonScriptsAttached", AttributeButtonScriptsAttached);

            ////ButtonScriptsAttached Child Nodes, still WIP:////
            //Utility.AddIfNotEmptyOrNull(userAttributes, "ButtonScript", AttributeButtonScript);
            //Utility.AddIfNotEmptyOrNull(userAttributes, "ButtonScriptAttachedRank", ButtonScriptAttachedRank);


            //tabs node is not allowed with Simple products;
            //Utility.AddIfNotEmptyOrNull(userProduct, "Tabs", Tabs);
            ////Tabs Child Nodes, still WIP:////
            //Utility.AddIfNotEmptyOrNull(userProduct, "TabsSystemId", TabsSystemId);
            //Utility.AddIfNotEmptyOrNull(userProduct, "TabsName", TabsName);
            //Utility.AddIfNotEmptyOrNull(userProduct, "TabsProductTabRank", TabsProductTabRank);
            //Utility.AddIfNotEmptyOrNull(userProduct, "TabsLayoutTemplate", TabsLayoutTemplate);
            //Utility.AddIfNotEmptyOrNull(userProduct, "TabsVisibilityPermission", TabsVisibilityPermission);
            //Utility.AddIfNotEmptyOrNull(userProduct, "TabsVisibilityCondition", TabsVisibilityCondition);
            //Utility.AddIfNotEmptyOrNull(userProduct, "TabsShowTabHeader", TabsShowTabHeader);
            //Utility.AddIfNotEmptyOrNull(userProduct, "TabsAttributes", TabsAttributes);
            //Utility.AddIfNotEmptyOrNull(userProduct, "TabsAttributesName", TabsAttributesName);
            //Utility.AddIfNotEmptyOrNull(userProduct, "TabsAttributesRank", TabsAttributesRank);

            //Utility.AddIfNotEmptyOrNull(userProduct, "GlobalScripts", GlobalScripts);
            ////GlobalScripts Child Nodes, still WIP:////
            //Utility.AddIfNotEmptyOrNull(userProduct, "GlobalScriptsName", GlobalScriptsName);
            //Utility.AddIfNotEmptyOrNull(userProduct, "GlobalScriptsRank", GlobalScriptsRank);
            //Utility.AddIfNotEmptyOrNull(userProduct, "GlobalScriptsEvents", GlobalScriptsEvents);
            //Utility.AddIfNotEmptyOrNull(userProduct, "GlobalScriptsEventsEvent", GlobalScriptsEventsEvent);

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
