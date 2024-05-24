using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Pr18_gl1_6;
using SSU.ThreeLayer.Entities;

namespace SSU.ThreeLayer.DAL
{
    public class BaseProducts : IBaseProducts
    {
        private List<Product> products;

        public BaseProducts()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream f = new FileStream("products.dat", FileMode.OpenOrCreate);
            if (f.Length == 0) // файл пуст, создаем новую базу
            {
                products = new List<Product>();
            }
            else // иначе выполняем десериализацию
            {
                products = (List<Product>)formatter.Deserialize(f);
            }
            f.Close();
        }

        ~BaseProducts()
        {
            SaveBaseProducts();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void DeleteProduct(string name)
        {
            products.RemoveAll(p => p.Name_Product == name);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProduct(string name)
        {
            return products.FirstOrDefault(p => p.Name_Product == name);
        }

        public IEnumerable<Product> GetExpiredProducts(DateTime currentDate)
        {
            return products.Where(p => p.IsExpired(currentDate.ToString())).ToList();
        }

        private void SaveBaseProducts()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream f = new FileStream("products.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(f, products);
            }
        }
    }
}