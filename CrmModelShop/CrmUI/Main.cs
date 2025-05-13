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
        /// Переменная контекста
        /// </summary>
        CrmContext crmContext;

        /// <summary>
        /// Клиент
        /// </summary>
        Customer Customer { get; set; }

        /// <summary>
        /// Корзина клиента
        /// </summary>
        Cart CustomerCart { get; set; }

        /// <summary>
        /// Касса
        /// </summary>
        CashBox CashBox { get; set; }

        /// <summary>
        /// Продавец
        /// </summary>
        Seller Seller { get; set; }

        /// <summary>
        /// Свойство для инициализации списка продуктов из базы данных
        /// </summary>
        List<Product> ListOfProducts { get; set; }

        /// <summary>
        /// Конструктор для основной формы
        /// </summary>
        public Main()
        {
            InitializeComponent();
            //инициализация переменной контекста
            crmContext = new CrmContext();
            //ListOfProducts = crmContext.Products.ToList();
        }

        /// <summary>
        /// Метод отображения товаров из базы данных при нажатии на товары
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
        /// Метод отображения клиентов из базы данных при нажатии на клиентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog<Customer> catalogCustomer = new Catalog<Customer>(crmContext.Customers, crmContext);
            catalogCustomer.Show();
        }

        /// <summary>
        /// Метод отображения продавцов из базы данных при нажатии на продавцов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog<Seller> catalogSeller = new Catalog<Seller>(crmContext.Sellers, crmContext);
            catalogSeller.Show();
        }

        /// <summary>
        /// Метод отображения заказов из базы данных при нажатии на заказы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog<Order> catalogOrder = new Catalog<Order>(crmContext.Orders, crmContext);
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
            Change_Main(sender, true);
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

        /// <summary>
        /// Метод отображающий форму компьютерного моделирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelForm modelForm = new ModelForm();
            modelForm.Show();
        }

        /// <summary>
        /// Метод срабатывающий на загрузке формы
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
        /// Метод добавления из списка listBoxProducts товара в listBoxCart
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
        /// Метод обновления списков при добавлении товара и общей цены товаров
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
        /// Метод при нажатии на кнопку Авторизация
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
        /// Метод при нажатии на кнопку Оплатить
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
        /// Приватный метод реализующий появление события
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
