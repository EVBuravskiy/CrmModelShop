using Microsoft.EntityFrameworkCore;
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
    /// Класс каталога использующий изменяемый тип данных для отображения таблицы данных из базы данных
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class Catalog<T> : Form
        where T : class
    {
        /// <summary>
        /// Конструктор создания таблицы
        /// </summary>
        /// <param name="dbSet"></param>
        public Catalog(DbSet<T> dbSet)
        {
            //Инициализируем форму
            InitializeComponent();
            //В качестве данных для заполнения таблицы используем данные из базы данных
            //List<T> list = dbSet.ToList();
            dataGridView.DataSource = dbSet.ToList();
        }
    }
}
