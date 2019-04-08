using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace CPQUtilities
{
    //    <CatalogueCodes>
    //  <CatalogueCode>A2223A</CatalogueCode>
    //  <CatalogueCode>A2223B</CatalogueCode>
    //  <CatalogueCode>A2223C</CatalogueCode>
    //</CatalogueCodes>
    //http://help.webcomcpq.com/doku.php?id=appendixd:validatecataloguecodeswebmethod:validatecataloguecodeinputparameters


    public class ValidateCatalogueCodes
    {
        public string CatalogueCode { get; set; }


        public ValidateCatalogueCodes()
            {
            //defaults
            }

        public XmlDocument CreateXml()
        {
            //    <CatalogueCodes>
            //  <CatalogueCode>A2223A</CatalogueCode>
            //  <CatalogueCode>A2223B</CatalogueCode>
            //  <CatalogueCode>A2223C</CatalogueCode>
            //</CatalogueCodes>

            XmlDocument retVal = new XmlDocument();


            XmlNode catalogueCodes = retVal.CreateElement("CatalogueCodes");
            retVal.AppendChild(catalogueCodes);

            Utility.AddIfNotEmptyOrNull(catalogueCodes, "CatalogueCode", CatalogueCode);

            return retVal;
        }

    }
}
