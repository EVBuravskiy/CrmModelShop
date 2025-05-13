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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CrmUI
{
    /// <summary>
    /// Product form
    /// </summary>
    public partial class ProductForm : Form
    {
        /// <summary>
        /// Property Product
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Product form constructor
        /// </summary>
        public ProductForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializing form data constructor
        /// </summary>
        /// <param name="product"></param>
        public ProductForm(Product product) : this()
        {
            Product = product ?? new Product();
            nameBox.Text = Product.ProductName;
            priceBox.Value = Product.ProductPrice;
            countBox.Value = Product.ProductCount;
        }

        /// <summary>
        /// Add product from form to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Product = Product ?? new Product();
            Product.ProductName = nameBox.Text.ToString();
            Product.ProductPrice = priceBox.Value;
            Product.ProductCount = Convert.ToInt32(countBox.Value);
            Close();
        }
    }
}
