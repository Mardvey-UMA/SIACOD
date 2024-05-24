using System;
using System.Windows.Forms;
using SSU.ThreeLayer.BLL;
using SSU.ThreeLayer.DAL;
using SSU.ThreeLayer.Entities;
using SSU.ThreeLayer.Common;
using Pr18_gl1_6;

namespace SSU.ThreeLayer.GUI
{
    public partial class Form1 : Form
    {
        private IClientLogic clientLogic;
        private IProductService productService;

        public Form1()
        {
            InitializeComponent();

            // Инициализация зависимости
            clientLogic = DependencyResolver.ClientLogic;
            productService = DependencyResolver.ProductService;

            // Подключение обработчиков событий
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);

            // Обновление списка клиентов и продуктов при загрузке формы
            UpdateClientList();
            UpdateProductList();
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            string clientName = txtClientName.Text;
            if (!string.IsNullOrWhiteSpace(clientName))
            {
                clientLogic.AddClient(clientName);
                UpdateClientList();
                txtClientName.Clear();
            }
            else
            {
                MessageBox.Show("Введите имя клиента.");
            }
        }

        //private void btnAddProduct_Click(object sender, EventArgs e)
        //{
        //    string productName = txtProductName.Text;
        //    int productQuantity = (int)numProductQuantity.Value;

        //    DateTime productStartDate = dtpProductStartDate.Value;
        //    DateTime productEndDate = dtpProductEndDate.Value;

        //    string startDateString = productStartDate.ToShortDateString();
        //    string endDateString = productEndDate.ToShortDateString();

        //    if (!string.IsNullOrWhiteSpace(productName))
        //    {
        //        productService.AddProduct(new Element(productName, productQuantity, productStartDate, productEndDate));
        //        UpdateProductList();
        //        txtProductName.Clear();
        //        numProductQuantity.Value = 0;
        //        dtpProductStartDate.Value = DateTime.Now;
        //        dtpProductEndDate.Value = DateTime.Now;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Введите название продукта.");
        //    }
        //}

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text;
            int productQuantity = (int)numProductQuantity.Value;
            DateTime productStartDate = dtpProductStartDate.Value;
            DateTime productEndDate = dtpProductEndDate.Value;
            string startDateString = productStartDate.ToShortDateString();
            string endDateString = productEndDate.ToShortDateString();

            if (!string.IsNullOrWhiteSpace(productName))
            {
                // Создание объекта Element с помощью конструктора класса Element
                Element newElement = new Element(productName, productQuantity, startDateString, endDateString);

                // Передача объекта newElement в метод AddProduct вашего ProductService
                productService.AddProduct(newElement);

                // Обновление списка продуктов
                UpdateProductList();

                // Очистка полей ввода после добавления продукта
                txtProductName.Clear();
                numProductQuantity.Value = 0;
                dtpProductStartDate.Value = DateTime.Now;
                dtpProductEndDate.Value = DateTime.Now;
            }
            else
            {
                MessageBox.Show("Введите название продукта.");
            }
        }

        private void UpdateClientList()
        {
            lstClients.Items.Clear();
            foreach (Client client in clientLogic.GetAllClients()) // Явное указание типа Client
            {
                lstClients.Items.Add($"ID: {client.Id}, Name: {client.Name}");
            }
        }

        private void UpdateProductList()
        {
            lstProducts.Items.Clear();
            foreach (var product in productService.GetAllProducts())
            {
                lstProducts.Items.Add($"Name: {product.Name}, Quantity: {product.Quantity}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Обновление списка клиентов и продуктов при загрузке формы
            UpdateClientList();
            UpdateProductList();
        }

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
