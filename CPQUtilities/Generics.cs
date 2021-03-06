﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CPQUtilities
{
    public class Translations : Hashtable
    {
        public Translations() { }
        public Translations(string EnglishLabel)
        {
            this.Add("USEnglish", EnglishLabel);
        }

        internal string ToXML()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string key in Keys)
            {
                sb.AppendLine(string.Format("<{0}><![CDATA[{1}]]></{0}>", key, this[key]));
                
            }




            return sb.ToString(); //old working code
        }

        //internal void AddToXML (XmlNode parentNode)
        //{
        //    if (this.Count == 0)
        //        return;

        //    XmlNode newNode = parentNode.OwnerDocument.CreateElement("ProductName");
        //    Translations temp = GetSingleSet();
        //    foreach (string key in temp.Keys)
        //    {
        //        XmlNode newLanguageNode = parentNode.OwnerDocument.CreateElement(key);
        //        newLanguageNode.AppendChild(parentNode.OwnerDocument.CreateCDataSection((string)temp[key]));
        //        newNode.AppendChild(newLanguageNode);

        //    }
        //    parentNode.AppendChild(newNode);
        //}

        
    }

    public class CategoryList : List<Translations>
    {
        private Translations GetSingleSet()
        {
            Translations temp = new Translations();

            foreach (Translations t in this)
            {
                foreach (string key in t.Keys)
                {
                    if (temp.ContainsKey(key))
                        temp[key] += ";" + t[key];
                    else
                        temp.Add(key, t[key] + "");
                }
            }

            return temp;

            //StringBuilder sb = new StringBuilder();

            //foreach (string key in temp.Keys)
            //    sb.AppendLine(string.Format("<{0}><![CDATA[{1}]]></{0}>", key, temp[key]));



            //return sb.ToString(); //old working code
        }

        internal void AddToXML(XmlNode parentNode)
        {

            //    <Categories>
            //      <USEnglish><![CDATA[Cardio>Excite+ Class]]></USEnglish>
            //      <French><![CDATA[Cardios>Excites+ Class]]></French>
            //    </Categories>


            if (this.Count == 0)
                return;

            XmlNode newNode = parentNode.OwnerDocument.CreateElement("Categories");
            Translations temp = GetSingleSet();
            foreach (string key in temp.Keys)
            {
                XmlNode newLanguageNode = parentNode.OwnerDocument.CreateElement(key);
                newLanguageNode.AppendChild(parentNode.OwnerDocument.CreateCDataSection((string)temp[key]));
                newNode.AppendChild(newLanguageNode);

            }
            parentNode.AppendChild(newNode);

        }
    }

    public class ProductList : List<Translations>
    {
        private Translations GetSingleSet()
        {
            Translations temp = new Translations();

            foreach (Translations t in this)
            {
                foreach (string key in t.Keys)
                {
                    if (temp.ContainsKey(key))
                        temp[key] += t[key] + "";
                    else
                        temp.Add(key, t[key] + "");
                }
            }
            return temp;

            //StringBuilder sb = new StringBuilder();

            //foreach (string key in temp.Keys)
            //    sb.AppendLine(string.Format("<{0}><![CDATA[{1}]]></{0}>", key, temp[key]));



            //return sb.ToString(); //old working code
        }

        internal void AddToXML(XmlNode parentNode)
        {

            //    <ProductName>
            //    < USEnglish >< ![CDATA[Step Excite + 500]] ></ USEnglish >
             //   < French >< ![CDATA[Step Excite + 500]] ></ French >
            //    </ ProductName >


            if (this.Count == 0)
                return;

            XmlNode newNode = parentNode.OwnerDocument.CreateElement("ProductName");
            Translations temp = GetSingleSet();
            foreach (string key in temp.Keys)
            {
                XmlNode newLanguageNode = parentNode.OwnerDocument.CreateElement(key);
                newLanguageNode.AppendChild(parentNode.OwnerDocument.CreateCDataSection((string)temp[key]));
                newNode.AppendChild(newLanguageNode);

            }
            parentNode.AppendChild(newNode);

        }
    }

    public class AttributeList : List<Translations>
    {
        private Translations GetSingleSet()
        {
            Translations temp = new Translations();

            foreach (Translations t in this)
            {
                foreach (string key in t.Keys)
                {
                    if (temp.ContainsKey(key))
                        temp[key] += t[key] + "";
                    else
                        temp.Add(key, t[key] + "");
                }
            }
            return temp;

            //StringBuilder sb = new StringBuilder();

            //foreach (string key in temp.Keys)
            //    sb.AppendLine(string.Format("<{0}><![CDATA[{1}]]></{0}>", key, temp[key]));



            //return sb.ToString(); //old working code
        }

        internal void AddToXML(XmlNode parentNode)
        {

            //    <AttributeName>
          //      < USEnglish >< ![CDATA[VERSION]] ></ USEnglish >
         //       < French >< ![CDATA[VERSIONE]] ></ French >
        //        </ AttributeName >


            if (this.Count == 0)
                return;

            XmlNode newNode = parentNode.OwnerDocument.CreateElement("AttributeName");
            Translations temp = GetSingleSet();
            foreach (string key in temp.Keys)
            {
                XmlNode newLanguageNode = parentNode.OwnerDocument.CreateElement(key);
                newLanguageNode.AppendChild(parentNode.OwnerDocument.CreateCDataSection((string)temp[key]));
                newNode.AppendChild(newLanguageNode);

            }
            parentNode.AppendChild(newNode);

        }
    }

    public class AttributeValueList : List<Translations>
    {
        private Translations GetSingleSet()
        {
            Translations temp = new Translations();

            foreach (Translations t in this)
            {
                foreach (string key in t.Keys)
                {
                    if (temp.ContainsKey(key))
                        temp[key] += t[key] + "";
                    else
                        temp.Add(key, t[key] + "");
                }
            }
            return temp;

            //StringBuilder sb = new StringBuilder();

            //foreach (string key in temp.Keys)
            //    sb.AppendLine(string.Format("<{0}><![CDATA[{1}]]></{0}>", key, temp[key]));



            //return sb.ToString(); //old working code
        }

        internal void AddToXML(XmlNode parentNode)
        {

            //    <Value>
            //    < USEnglish >< ![CDATA[500]] ></ USEnglish >
            //   < French >< ![CDATA[500]] ></ French >
            //    </Value>


            if (this.Count == 0)
                return;

            XmlNode newNode = parentNode.OwnerDocument.CreateElement("Value");
            Translations temp = GetSingleSet();
            foreach (string key in temp.Keys)
            {
                XmlNode newLanguageNode = parentNode.OwnerDocument.CreateElement(key);
                newLanguageNode.AppendChild(parentNode.OwnerDocument.CreateCDataSection((string)temp[key]));
                newNode.AppendChild(newLanguageNode);

            }
            parentNode.AppendChild(newNode);

        }
    }
}
