using CrmBL.Models;
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
        /// Database context
        /// </summary>
        CrmContext crmContext;

        /// <summary>
        /// Property Customer
        /// </summary>
        Customer Customer { get; set; }

        /// <summary>
        /// Property Customer's cart
        /// </summary>
        Cart CustomerCart { get; set; }

        /// <summary>
        /// Property Cashbox
        /// </summary>
        CashBox CashBox { get; set; }

        /// <summary>
        /// Property Seller
        /// </summary>
        Seller Seller { get; set; }

        /// <summary>
        /// Property collection of products
        /// </summary>
        List<Product> ListOfProducts { get; set; }

        /// <summary>
        /// Main Form constructor
        /// </summary>
        public Main()
        {
            InitializeComponent();
            crmContext = new CrmContext();
        }

        /// <summary>
        /// Displaying products from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog<Product> catalogProduct = new Catalog<Product>(crmContext.Products, crmContext);
            catalogProduct.Show();
            catalogProduct.CatalogWasChanged += Change_Main;
        }

        /// <summary>
        /// Displaying clients from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog<Customer> catalogCustomer = new Catalog<Customer>(crmContext.Customers, crmContext);
            catalogCustomer.Show();
        }

        /// <summary>
        /// Displaying sellers from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog<Seller> catalogSeller = new Catalog<Seller>(crmContext.Sellers, crmContext);
            catalogSeller.Show();
        }

        /// <summary>
        /// Displaying orders from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog<Order> catalogOrder = new Catalog<Order>(crmContext.Orders, crmContext);
            catalogOrder.Show();
        }

        /// <summary>
        /// Add product to the database
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
            Change_Main(sender, true);
        }

        /// <summary>
        /// Adding a customer to the database
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
        /// Adding a seller to the database
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

        /// <summary>
        /// Display computer model form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelForm modelForm = new ModelForm();
            modelForm.Show();
        }

        /// <summary>
        /// Load Main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                listBoxProducts.Invoke((Action)delegate
                {
                    ListOfProducts = crmContext.Products.ToList();
                });
                listBoxCart.Invoke((Action)delegate
                {
                    UpdateLists();
                });
            });
        }

        /// <summary>
        /// Add products from listBoxProducts to listBoxCart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxProducts_DoubleClick(object sender, EventArgs e)
        {
            if(Customer == null)
            {
                MessageBox.Show("Авторизуйтесь, пожалуйста!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (listBoxProducts.SelectedItem is Product product)
            {
                Product tempProduct = ListOfProducts.FirstOrDefault(pr => pr.ProductId == product.ProductId);
                tempProduct.ProductCount--;
                CustomerCart.AddToCart(product);
                listBoxCart.Items.Add(product);
                UpdateLists();
            }
        }

        /// <summary>
        /// Update lists of products
        /// </summary>
        private void UpdateLists()
        {
            listBoxProducts.Items.Clear();
            listBoxProducts.Items.AddRange(ListOfProducts.Where(p => p.ProductCount > 0).ToArray());
            if (Customer != null)
            {
                listBoxCart.Items.Clear();
                listBoxCart.Items.AddRange(CustomerCart.GetAllFromCart().ToArray());
                label1.Text = $"Итого: {CustomerCart.TotalCost} рублей";
            }
        }

        /// <summary>
        /// Start of authorization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabelAuthorisation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Authorization authorizationForm = new Authorization();
            authorizationForm.ShowDialog();
            if (authorizationForm.DialogResult == DialogResult.OK)
            {
                Customer tempCustomer = crmContext.Customers.SingleOrDefault(c => c.CustomerName.Equals(authorizationForm.Customer.CustomerName));
                if (tempCustomer != null)
                {
                    Customer = tempCustomer;
                }
                else
                {
                    crmContext.Customers.Add(authorizationForm.Customer);
                    crmContext.SaveChanges();
                    Customer = authorizationForm.Customer;
                }
                linkLabelAuthirisation.Text = $"Добро пожаловать, {Customer.CustomerName}!";
                linkLabelAuthirisation.Enabled = false;
                CustomerCart = new Cart(Customer);
            }
        }

        /// <summary>
        /// Start of payment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPay_Click(object sender, EventArgs e)
        {
            if(Customer != null)
            {
                Seller seller = crmContext.Sellers.FirstOrDefault();
                decimal sum = 0;
                if (seller != null && CustomerCart != null)
                {
                    CashBox = new CashBox(1, seller, crmContext);
                    CashBox.IsModel = false;
                    if (CustomerCart.Products.Count > 0)
                    {
                        CashBox.Enqueue(CustomerCart);
                        sum = CashBox.Dequeue();
                    }
                    CashBox.IsModel = true;
                }
                listBoxCart.Items.Clear();
                label1.Text = $"Итого: ";
                if (sum > 0)
                {
                    MessageBox.Show($"Поздравляю, {Customer.CustomerName}! Вами совершена покупка на сумму {sum}", "Покупка выполнена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CustomerCart = new Cart(Customer);
                }
            }
            else
            {
                MessageBox.Show("Авторизуйтесь, пожалуйста!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Update list of products when get event from catalog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="order"></param>
        private void Change_Main(object sender, bool flag)
        {
            if(flag)
            {
                ListOfProducts = crmContext.Products.ToList();
                UpdateLists();
            }
        }

    }
}
