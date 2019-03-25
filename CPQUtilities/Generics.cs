using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                sb.AppendLine(string.Format("<{0}><![CDATA[{1}]]></{0}>", key, this[key]));
            return sb.ToString();
        }
    }

    public class CategoryList : List<Translations>
    {
        internal string ToXML()
        {
            Translations temp = new Translations();

            foreach (Translations t in this)
            {
                foreach (string key in t.Keys)
                {
                    if (temp.ContainsKey(key))
                        temp[key] += t[key] + ";";
                    else
                        temp.Add(key, t[key] + ";");
                }
            }


            StringBuilder sb = new StringBuilder();
            foreach (string key in temp.Keys)
                sb.AppendLine(string.Format("<{0}><![CDATA[{1}]]></{0}>", key, temp[key]));

            return sb.ToString();
        }
    }
}
