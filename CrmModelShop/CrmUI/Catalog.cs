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
    /// Catalog for displaying products, customers and sellers
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class Catalog<T> : Form
        where T : class
    {
        /// <summary>
        /// Database context 
        /// </summary>
        CrmContext CrmContext { get; set; }

        /// <summary>
        /// Database Entity
        /// </summary>
        DbSet<T> dbSet;

        /// <summary>
        /// Event on catalog change
        /// </summary>
        public event EventHandler<bool> CatalogWasChanged;

        /// <summary>
        /// Catalog constructor
        /// </summary>
        /// <param name="dbSet"></param>
        public Catalog(DbSet<T> dbSet, CrmContext context)
        {
            InitializeComponent();
            this.dbSet = dbSet;
            dataGridView.DataSource = this.dbSet.ToList();
            CrmContext = context ?? new CrmContext();
        }
        /// <summary>
        /// Adding data from a form to a database
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
        /// Changing data from a form in a database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeButton_Click(object sender, EventArgs e)
        {
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
        /// Deleting form data from the database
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
