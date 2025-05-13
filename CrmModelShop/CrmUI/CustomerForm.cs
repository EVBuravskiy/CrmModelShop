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
        /// Property Customer
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Customer's form constructor
        /// </summary>
        public CustomerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Customer's form constructor
        /// </summary>
        /// <param name="customer"></param>
        public CustomerForm(Customer customer) : this()
        {
            Customer = customer ?? new Customer();
            nameBox.Text = Customer.CustomerName;
        }

        /// <summary>
        /// Add new customer from form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Customer = Customer ?? new Customer();
            Customer.CustomerName = nameBox.Text.ToString();
            Close();
        }
    }
}
