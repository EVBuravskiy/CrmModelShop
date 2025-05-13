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
    public partial class Authorization : Form
    {
        /// <summary>
        /// Customer
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Authorization constructor
        /// </summary>
        public Authorization()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Login by pressing the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Customer = new Customer() 
            { 
                CustomerName = textBoxName.Text 
            };
            DialogResult = DialogResult.OK;
        }
    }
}
