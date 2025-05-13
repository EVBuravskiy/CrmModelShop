using CrmBL.Models;
using Microsoft.EntityFrameworkCore;
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
    /// <summary>
    /// Класс каталога использующий изменяемый тип данных для отображения таблицы данных из базы данных
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class Catalog<T> : Form
        where T : class
    {
        /// <summary>
        /// Переменная контекста для работы с базой данных
        /// </summary>
        CrmContext CrmContext { get; set; }

        /// <summary>
        /// Переменная таблицы базы данной для нахождения элемента
        /// </summary>
        DbSet<T> dbSet;

        /// <summary>
        /// Событие, возвращающее заказ
        /// </summary>
        public event EventHandler<bool> CatalogWasChanged;

        /// <summary>
        /// Конструктор создания таблицы
        /// </summary>
        /// <param name="dbSet"></param>
        public Catalog(DbSet<T> dbSet, CrmContext context)
        {
            //Инициализируем форму
            InitializeComponent();
            //В качестве данных для заполнения таблицы используем данные из базы данных
            //List<T> list = dbSet.ToList();
            this.dbSet = dbSet;
            dataGridView.DataSource = this.dbSet.ToList();
            CrmContext = context ?? new CrmContext();
        }
        /// <summary>
        /// Метод на нажатие кнопки Добавить, через форму добавляет данные в БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            if (typeof(T) == typeof(Product))
            {
                ProductForm productForm = new ProductForm();
                if (productForm.ShowDialog() == DialogResult.OK)
                {
                    CrmContext.Products.Add(productForm.Product);
                    CrmContext.SaveChanges();
                    CatalogWasChanged?.Invoke(this, true);
                }
            }
            else if (typeof(T) == typeof(Customer))
            {
                CustomerForm customerForm = new CustomerForm();
                if (customerForm.ShowDialog() == DialogResult.OK)
                {
                    CrmContext.Customers.Add(customerForm.Customer);
                    CrmContext.SaveChanges();
                }
            }
            else if (typeof(T) == typeof(Seller))
            {
                SellerForm sellerForm = new SellerForm();
                if (sellerForm.ShowDialog() == DialogResult.OK)
                {
                    CrmContext.Sellers.Add(sellerForm.Seller);
                    CrmContext.SaveChanges();
                }
            }
            dataGridView.DataSource = this.dbSet.ToList();
            dataGridView.Update();
        }

        /// <summary>
        /// Метод на нажатие кнопки Изменить, ищет елемент посредством DbSet и через форму изменяет данные в БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeButton_Click(object sender, EventArgs e)
        {
            //получаем id - первая ячейка первой из выбранных строк
            var id = (int)dataGridView.SelectedRows[0].Cells[0].Value;

            if (typeof(T) == typeof(Product))
            {
                Product product = dbSet.Find(id) as Product;
                ProductForm productForm = null;
                if (product != null)
                {
                    productForm = new ProductForm(product);
                    if (productForm?.ShowDialog() == DialogResult.OK)
                    {
                        productForm.Product.ProductId = id;
                        CrmContext.Products.Update(productForm.Product);
                        CrmContext.SaveChanges();
                        CatalogWasChanged?.Invoke(this, true);
                    }
                }
            }
            else if (typeof(T) == typeof(Customer))
            {
                Customer customer = dbSet.Find(id) as Customer;
                CustomerForm customerForm = null;
                if (customer != null)
                {
                    customerForm = new CustomerForm(customer);
                    if (customerForm?.ShowDialog() == DialogResult.OK)
                    {
                        customerForm.Customer.CustomerId = id;
                        CrmContext.Customers.Update(customerForm.Customer);
                        CrmContext.SaveChanges();
                    }
                }
            }
            else if (typeof(T) == typeof(Seller))
            {
                Seller seller = dbSet.Find(id) as Seller;
                SellerForm sellerForm = null;
                if (seller != null)
                {
                    sellerForm = new SellerForm(seller);
                    if (sellerForm?.ShowDialog() == DialogResult.OK)
                    {
                        sellerForm.Seller.SellerId = id;
                        CrmContext.Sellers.Update(sellerForm.Seller);
                        CrmContext.SaveChanges();
                    }
                }
            }
            dataGridView.DataSource = this.dbSet.ToList();
            dataGridView.Update();
        }

        /// <summary>
        /// Метод на нажатие кнопки Удалить, через DbSet ищет элемент в базе данных и удаляет его
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            var id = (int)dataGridView.SelectedRows[0].Cells[0].Value;

            if (typeof(T) == typeof(Product))
            {
                Product product = dbSet.Find(id) as Product;
                if (product != null)
                {
                    CrmContext.Products.Remove(product);
                    CrmContext.SaveChanges();
                    CatalogWasChanged?.Invoke(this, true);
                }
            }

            else if (typeof(T) == typeof(Customer))
            {
                Customer customer = dbSet.Find(id) as Customer;
                if (customer != null)
                {
                    CrmContext.Customers.Remove(customer);
                    CrmContext.SaveChanges();
                }
            }
            else if (typeof(T) == typeof(Seller))
            {
                Seller seller = dbSet.Find(id) as Seller;
                if (seller != null)
                {
                    CrmContext.Sellers.Remove(seller);
                    CrmContext.SaveChanges();
                }
            }
            dataGridView.DataSource = this.dbSet.ToList();
            dataGridView.Update();
        }
    }
}
