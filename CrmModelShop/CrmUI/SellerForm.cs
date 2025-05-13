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
    /// <summary>
    /// Seller form
    /// </summary>
    public partial class SellerForm : Form
    {
        /// <summary>
        /// Property Seller
        /// </summary>
        public Seller Seller { get; set; }

        /// <summary>
        /// Seller form constructor
        /// </summary>
        public SellerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializing form data constructor
        /// </summary>
        /// <param name="seller"></param>
        public SellerForm(Seller seller) : this()
        {
            Seller = seller ?? new Seller();
            nameBox.Text = Seller.SellerName;
        }

        /// <summary>
        /// Add seller from form to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Seller = Seller ?? new Seller();
            Seller.SellerName = nameBox.Text.ToString();
            Close();
        }
    }
}
