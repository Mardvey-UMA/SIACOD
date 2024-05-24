    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    namespace Pr18_gl1_6
    {
        [XmlInclude(typeof(Element))]
        [Serializable]
        public class Element : Product
        {
        
            private string Name;
            private int Price;
            private string Production_Date;
            private string Expiry_Date;

            public override int Cost
            {
                get
                {
                    return Price;
                }
            }


            public override string ToString()
            {
                return ($"Product: {Name} \n Price: {Price} \n Production Date: {Production_Date} \n Expiry Date: {Expiry_Date}");
            }

            public Element()
            {

            }
            public Element(string name, int price, string productionDate, string expiryDate) : base(name)
            {
                this.Name = name;
                this.Price = price;
                this.Production_Date = productionDate;
                this.Expiry_Date = expiryDate;
            }

            public override bool IsExpired(string currentDate)
            {
                DateTime current_Date;
                if (DateTime.TryParse(currentDate, out current_Date))
                {
                    DateTime expiryDate;
                    if (DateTime.TryParse(Expiry_Date, out expiryDate))
                    {
                        return current_Date > expiryDate;
                    }
                    else
                    {
                        Console.WriteLine($"Error parsing expiry date for {Name}");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine($"Error parsing current date for {Name}");
                    return false;
                }
            }
        }
    }