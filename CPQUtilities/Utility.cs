using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CPQUtilities
{
    public static class Utility
    {
        internal static XmlNode AddIfNotEmptyOrNull(XmlNode parentNode, string nodeName, object value)
        {
            if (value == null)
                return null;

            XmlNode newNode = parentNode.OwnerDocument.CreateElement(nodeName);

            switch (value.GetType().Name)
            {
                case "String":
                    newNode.InnerText = (string)value;
                    parentNode.AppendChild(newNode);
                    break;

                case "DateTime":
                    newNode.InnerText = ((DateTime)value).ToString();
                    parentNode.AppendChild(newNode);
                    break;

                case "Int32":
                    newNode.InnerText = ((int)value).ToString();
                    parentNode.AppendChild(newNode);
                    break;

                default:
                    System.Diagnostics.Debug.WriteLine(value.GetType().Name);
                    break;
            }

            return newNode;
        }
    }
}
