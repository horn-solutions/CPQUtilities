using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CPQUtilities
{

    //<Crm>
    //  <OpportunityId>892ADE6756HIX</OpportunityId>
    //  <OpportunityName>Test Oppty</OpportunityName>
    //</Crm>


    public class LinkOpportunity
    {
        public string OpportunityId { get; set; }
        public string OpportunityName { get; set; }

        public LinkOpportunity()
        {
            //defaults
        }

        public XmlDocument CreateXml()
        {
            XmlDocument retVal = new XmlDocument();

            XmlNode nodeCrm = retVal.CreateElement("Crm");
            retVal.AppendChild(nodeCrm);

            Utility.AddIfNotEmptyOrNull(nodeCrm, "OpportunityId", OpportunityId);
            Utility.AddIfNotEmptyOrNull(nodeCrm, "OpportunityName", OpportunityName);
            return retVal;
        }

        public static LinkOpportunity LoadFromXml(XmlDocument xDoc)
        {
            LinkOpportunity retVal = new LinkOpportunity();

            // read the xml into fields

            return retVal;
        }
    }

    
}
