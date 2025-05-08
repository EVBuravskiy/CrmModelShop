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
        /// Метод создания клиента при нажатии на кнопку "Подтвердить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Customer = new Customer()
            {
                CustomerName = textBox1.Text.ToString()
            };
            Close();
        }
    }
}
