using SSU.ThreeLayer.BLL;
using SSU.ThreeLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ThreeLayer.Common
{
    public static class DependencyResolver
    {
        private static IBaseClients baseClients;
        private static IClientLogic clientLogic;
        private static IBaseProducts baseProducts;
        private static IProductService productService;

        public static IBaseClients BaseClients
        {
            get => baseClients ?? (baseClients = new BaseClients());
        }

        public static IClientLogic ClientLogic
        {
            get => clientLogic ?? (clientLogic = new ClientLogic(BaseClients));
        }

        public static IBaseProducts BaseProducts
        {
            get => baseProducts ?? (baseProducts = new BaseProducts());
        }

        public static IProductService ProductService
        {
            get => productService ?? (productService = new ProductService(BaseProducts));
        }
    }
}