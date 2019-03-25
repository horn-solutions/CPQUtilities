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
        public Translations(string EnglishLabel)
        {
            this.Add("USEnglish", EnglishLabel);
        }
    }

    public class CategoryList : ICollection<Translations>
    {
        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(Translations item) { this.Add(item); }

        public void Clear() { this.Clear(); }

        public bool Contains(Translations item)
        {
            throw new NotImplementedException();

        }

        public void CopyTo(Translations[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Translations> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Translations item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
