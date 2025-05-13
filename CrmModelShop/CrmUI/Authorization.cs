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
        /// Свойство создания экземпляра клиента
        /// </summary>
        public Customer Customer { get; set; }
        
        /// <summary>
        /// Конструктор
        /// </summary>
        public Authorization()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод при нажатии на кнопку Войти
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
