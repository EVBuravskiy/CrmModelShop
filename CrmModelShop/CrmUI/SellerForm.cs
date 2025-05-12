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
    public partial class SellerForm : Form
    {
        /// <summary>
        /// Свойство для экземпляра класса Продавца
        /// </summary>
        public Seller Seller { get; set; }

        /// <summary>
        /// Конструктор формы 
        /// </summary>
        public SellerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор формы, поля которого инициализированы переданным в него экземпляром класса Продавца
        /// </summary>
        /// <param name="seller"></param>
        public SellerForm(Seller seller) : this()
        {
            Seller = seller ?? new Seller();
            nameBox.Text = Seller.SellerName;
        }

        /// <summary>
        /// Метод выполняющийся при нажатии на кнопку Подтвердить
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
