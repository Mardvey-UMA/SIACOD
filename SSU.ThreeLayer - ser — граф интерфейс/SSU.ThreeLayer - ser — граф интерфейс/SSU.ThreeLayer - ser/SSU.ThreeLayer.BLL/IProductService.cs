using System;
using System.Collections.Generic;
using Pr18_gl1_6;
using SSU.ThreeLayer.Entities;

namespace SSU.ThreeLayer.BLL
{
    public interface IProductService
    {
        void AddProduct(Product product);
        void DeleteProduct(string name);
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(string name);
        IEnumerable<Product> GetExpiredProducts(DateTime currentDate);
    }
}