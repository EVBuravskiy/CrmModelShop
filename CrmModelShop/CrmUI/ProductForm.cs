﻿using CrmBL.Models;
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
    public partial class ProductForm : Form
    {
        /// <summary>
        /// Свойство - класс Product
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Конструктор инициализирующий форму
        /// </summary>
        public ProductForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Конструктор инициализирующий форму данными переданного в нее Товара
        /// </summary>
        /// <param name="product"></param>
        public ProductForm(Product product) : this()
        {
            Product = product;
            nameBox.Text = product.ProductName;
            priceBox.Value = product.ProductPrice;
            countBox.Value = product.ProductCount;
        }

        /// <summary>
        /// Метод вызываемый при нажатии на кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (Product == null) {
                //Создает экземпляр класса Product и присваивает его полям значения из формы
                Product = new Product();
            }
            Product.ProductName = nameBox.Text.ToString();
            Product.ProductPrice = priceBox.Value;
            Product.ProductCount = Convert.ToInt32(countBox.Value);
            //Закрывает форму
            Close();
        }
    }
}
