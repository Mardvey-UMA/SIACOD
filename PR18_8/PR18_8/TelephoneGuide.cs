using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Telephone
{
    [Serializable]
    abstract public class TelephoneGuide:IComparable<TelephoneGuide>
    {
        protected string number;
        public int CompareTo(TelephoneGuide item)
        {
            return this.GetNumber().CompareTo(item.GetNumber());
        }
        abstract public void GetInfo();
        abstract public bool[] InGuide(params string[] args);
        abstract public void Set(params string[] args);
        public string GetNumber()
        {
            Regex non_num = new Regex(@"[^\d]+");
            string tmp = this.number;
            tmp = non_num.Replace(tmp, "");
            return tmp;
        }
    }
}
