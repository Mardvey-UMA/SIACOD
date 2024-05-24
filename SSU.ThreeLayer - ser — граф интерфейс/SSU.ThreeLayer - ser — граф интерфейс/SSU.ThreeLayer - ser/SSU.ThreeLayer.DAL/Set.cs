using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pr18_gl1_6
{
    [XmlInclude(typeof(Set))]
    [Serializable]
    public class Set : Product
    {

        protected string Name;
        protected int Price;
        public List<Product> Products;

        public Set()
        {

        }
        public Set(string name, int price, List<Product> Products) : base(name)
        {
            this.Name = name;
            this.Price = price;
            this.Products = new List<Product>();

        }


        public override int Cost
        {
            get
            {
                return Price;
            }
        }
        public override string ToString()
        {
            string productInfo = string.Join("\n", Products.Select(p => p.ToString()));
            return $"Set: {Name} \nPrice: {Price} \nProducts: \n{productInfo}";
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }


        public override bool IsExpired(string currentDate)
        {
            DateTime current_Date = DateTime.Now;
            return Products.Any(product => product.IsExpired(currentDate));
        }
    }
}