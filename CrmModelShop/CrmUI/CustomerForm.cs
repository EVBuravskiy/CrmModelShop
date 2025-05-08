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
    public partial class CustomerForm : Form
    {
        /// <summary>
        /// Свойство создания клиента
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Конструктор для создания формы клиента
        /// </summary>
        public CustomerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор для создания формы клиента с внесенными в нее данными из переданного экземпляра клиента
        /// </summary>
        /// <param name="customer"></param>
        public CustomerForm(Customer customer) : this()
        {
            Customer = customer;
            nameBox.Text = customer.CustomerName;
        }

        /// <summary>
        /// Метод создания клиента при нажатии на кнопку "Подтвердить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (Customer == null) 
            {
                Customer = new Customer(); 
            }
            Customer.CustomerName = nameBox.Text.ToString();
            Close();
        }
    }
}
