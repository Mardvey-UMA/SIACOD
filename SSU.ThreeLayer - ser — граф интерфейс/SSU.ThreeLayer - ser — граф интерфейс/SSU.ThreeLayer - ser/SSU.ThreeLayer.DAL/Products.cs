using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pr18_gl1_6
{
    [XmlInclude(typeof(Element))]
    [XmlInclude(typeof(Batch))]
    [XmlInclude(typeof(Set))]
    [Serializable]
    abstract public class Product : IComparable<Product>
    {

        public string Name_Product { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public int CompareTo(Product item)
        {
            return this.Cost.CompareTo(item.Cost);
        }
        public Product()
        {

        }
        public Product(string name)
        {
            this.Name_Product = name;
        }
        public abstract bool IsExpired(string currentDate);
        public abstract int Cost { get; }
    }

}
