using SSU.ThreeLayer.BLL;
using SSU.ThreeLayer.Common;
using SSU.ThreeLayer.Entities;
using SSU.ThreeLayer.DAL;
using System;
using Pr18_gl1_6;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ThreeLayer.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dependency Injection (в реальном приложении может быть более сложным)
            IBaseClients clientRepository = new BaseClients();
            IClientLogic clientLogic = new ClientLogic(clientRepository);

            IBaseProducts productRepository = new BaseProducts();
            IProductService productService = new ProductService(productRepository);

            // Работа с клиентами
            Console.WriteLine("Исходная выгрузка");
            ShowClients(clientLogic);

            clientLogic.AddClient("Иванов");
            clientLogic.AddBuying(1, new DateTime(2009, 2, 1), 1000);
            clientLogic.AddBuying(1, new DateTime(2009, 2, 1), 2050);
            clientLogic.AddClient("Петров");
            clientLogic.AddClient("Сидоров");
            clientLogic.AddBuying(3, new DateTime(2009, 2, 3), 1500);
            clientLogic.AddBuying("Петров", new DateTime(2009, 2, 4), 1700);
            clientLogic.AddClient("Пирогов");

            Console.WriteLine("\nУточненная база клиентов");
            ShowClients(clientLogic);
            clientLogic.DeleteClient(2);
            clientLogic.DeleteClient("Пирогов");

            Console.WriteLine("\nИзмененная база клиентов");
            ShowClients(clientLogic);

            // Работа с продуктами
            productService.AddProduct(new Element("Молоко", 50, "2023-05-01", "2023-05-10"));
            productService.AddProduct(new Batch("Яблоки", 100, 10, "2023-05-01", "2023-05-20"));
            productService.AddProduct(new Set("Набор фруктов", 150, new List<Product>
        {
            new Element("Банан", 30, "2023-05-01", "2023-05-15"),
            new Element("Яблоко", 20, "2023-05-01", "2023-05-10")
        }));

            Console.WriteLine("Все товары:");
            ShowProducts(productService.GetAllProducts());

            Console.WriteLine("\nПросроченные товары:");
            ShowProducts(productService.GetExpiredProducts(DateTime.Now));

            productService.DeleteProduct("Молоко");

            Console.WriteLine("\nВсе товары после удаления:");
            ShowProducts(productService.GetAllProducts());
        }

        static void ShowClients(IClientLogic clientLogic)
        {
            foreach (Client client in clientLogic.GetAllClients())
            {
                Console.WriteLine("№{0}", client.id); // выводим номер клиента
                Console.WriteLine(client); // выводим информацию о клиенте на экран
            }
        }

        static void ShowProducts(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
