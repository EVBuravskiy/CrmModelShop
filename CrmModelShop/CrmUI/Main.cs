﻿using CrmBL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class Main : Form
    {
        /// <summary>
        /// Переменная контекста
        /// </summary>
        CrmContext crmContext;

        /// <summary>
        /// Конструктор для основной формы
        /// </summary>
        public Main()
        {
            InitializeComponent();
            //инициализация переменной контекста
            crmContext = new CrmContext();
        }

        /// <summary>
        /// Метод отображения товаров из базы данных при нажатии на товары
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog<Product> catalogProduct = new Catalog<Product>(crmContext.Products);
            catalogProduct.Show();
        }

        /// <summary>
        /// Метод отображения клиентов из базы данных при нажатии на клиентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog<Customer> catalogCustomer = new Catalog<Customer>(crmContext.Customers);
            catalogCustomer.Show();
        }

        /// <summary>
        /// Метод отображения продавцов из базы данных при нажатии на продавцов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog<Seller> catalogSeller = new Catalog<Seller>(crmContext.Sellers);
            catalogSeller.Show();
        }

        /// <summary>
        /// Метод отображения заказов из базы данных при нажатии на заказы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog<Order> catalogOrder = new Catalog<Order>(crmContext.Orders);
            catalogOrder.Show();
        }

        /// <summary>
        /// Метод добавления товара в базу данных из формы товара
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductAdd_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            if (productForm.ShowDialog() == DialogResult.OK)
            {
                crmContext.Products.Add(productForm.Product);
                crmContext.SaveChanges();
            }
        }

        /// <summary>
        /// Метод сохранения клиента в базу данных из формы клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerAdd_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            if(customerForm.ShowDialog() == DialogResult.OK)
            {
                crmContext.Customers.Add(customerForm.Customer);
                crmContext.SaveChanges();
            }
        }

        /// <summary>
        /// Метод добавления продавца в базу данных из формы продавца
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SellerAdd_Click(object sender, EventArgs e)
        {
            SellerForm sellerForm = new SellerForm();
            if (sellerForm.ShowDialog() == DialogResult.OK)
            {
                crmContext.Sellers.Add(sellerForm.Seller);
                crmContext.SaveChanges();
            }
        }

    }
}
