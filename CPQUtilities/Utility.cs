using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Security.Cryptography;


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

        public static String RandomPassword(int size=8)
        {

            //generate a random password, for when creating users. taken from: https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
            string retVal = "";

            char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%".ToCharArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
           
            retVal = result.ToString();
            return retVal;
        }
    }
}
