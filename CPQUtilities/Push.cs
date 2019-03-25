using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace CPQUtilities
{
    public static class Push
    {
        public static bool Product(string name)
        {
            bool retVal = false;



            return retVal;
        }

        public static void AddProduct(string username, string password, string productName)
        {
            //adding a product

            //complete list of WsSrv operations: https://www.webcomcpq.com/wsAPI/wssrv.asmx


            WsSrv.WsSrv service = new WsSrv.WsSrv();
            //wait 200 seconds:
            service.Timeout = 200 * 1000;

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(string.Format(@"
<Products>
    <Product>
        <Identificator>PartNumber</Identificator>
        <DisplayType>Simple</DisplayType>
        <PartNumber>Test {0}</PartNumber>
        <ProductType>Accessories</ProductType>
        <ProductName>
            <USEnglish><![CDATA[{0}]]></USEnglish>
        </ProductName>
        <StartDate>3/3/15</StartDate>
        <EndDate>5/5/18</EndDate>
        <Categories>
            <USEnglish><![CDATA[Test]]></USEnglish>
        </Categories>
    </Product>
</Products>
", productName));

            XmlNode response = service.SimpleProductAdministration(username, password, "ADDORUPDATE", xDoc);


        }
    }
}
