using System;
using System.Collections.Generic;
using Pr18_gl1_6;
using SSU.ThreeLayer.DAL;
using SSU.ThreeLayer.Entities;

namespace SSU.ThreeLayer.BLL
{
    public class ProductService : IProductService
    {
        private readonly IBaseProducts _productRepository;

        public ProductService(IBaseProducts productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public void DeleteProduct(string name)
        {
            _productRepository.DeleteProduct(name);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product GetProduct(string name)
        {
            return _productRepository.GetProduct(name);
        }

        public IEnumerable<Product> GetExpiredProducts(DateTime currentDate)
        {
            return _productRepository.GetExpiredProducts(currentDate);
        }
    }
}