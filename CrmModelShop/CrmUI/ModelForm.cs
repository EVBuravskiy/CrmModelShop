using CrmBL.Models;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class ModelForm : Form
    {
        //Подключаем и инициализируем компьютерную модель
        ShopComputerModel computerModel = new ShopComputerModel();
        public ModelForm()
        {
            InitializeComponent();
            //Инициализируем поля компьютерной модели начальными значениями из формы
            computerModel.CashBoxCount = Convert.ToInt32(CashBoxCount.Value);
            computerModel.CustomersProductCount = Convert.ToInt32(ProductsCount.Value);
            computerModel.CustomersCount = Convert.ToInt32(CustomersCount.Value);
            computerModel.CustomersSpeed = Convert.ToInt32(CustomerSpeed.Value);
            computerModel.CashBoxSpeed = Convert.ToInt32(CashBoxSpeed.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Создаем список элементов CashBoxView
            List<CashBoxView> cashBoxViews = new List<CashBoxView>();

            //Запускаем компьютерную модель
            computerModel.Start();
            button1.Hide();

            //Исходя из количества касс в компьютерной модели 
            for (int i = 0; i < computerModel.CashBoxCount; i++)
            {
                //Создаем экземпляр класса CashBoxView и задаем ему начальные свойства
                CashBoxView newCashBoxView = new CashBoxView(computerModel.CashBoxes[i], i, 10, 26 * i);
                //Заполняем список элементов CashBoxView
                cashBoxViews.Add(newCashBoxView);
                //Добавляем элементы на форму
                Controls.Add(newCashBoxView.CashBoxName);
                Controls.Add(newCashBoxView.Price);
                Controls.Add(newCashBoxView.QueueLenght);
                Controls.Add(newCashBoxView.LeaveCustomersCount);
            }

        }

        /// <summary>
        /// Приватный метод корректно останавливающий модель при закрытии формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            computerModel.Stop();
        }

        /// <summary>
        /// Метод возвращающий текущие параметры модели в форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModelForm_Load(object sender, EventArgs e)
        {
            CashBoxCount.Value = computerModel.CashBoxCount;
            ProductsCount.Value = computerModel.CustomersProductCount;
            CustomersCount.Value = computerModel.CustomersCount;
            CustomerSpeed.Value = computerModel.CustomersSpeed;
            CashBoxSpeed.Value = computerModel.CashBoxSpeed;
        }
        
        /// <summary>
        /// Методы инициализирующие поля модели данными из формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CashBoxCount_ValueChanged(object sender, EventArgs e)
        {
            computerModel.CashBoxCount = Convert.ToInt32(CashBoxCount.Value);
        }
        private void ProductsCount_ValueChanged(Object sender, EventArgs e)
        {
            computerModel.CustomersProductCount = Convert.ToInt32(ProductsCount.Value);
        }
        private void CustomersCount_ValueChanged(Object sender, EventArgs e)
        {
            computerModel.CustomersCount = Convert.ToInt32(CustomersCount.Value);
        }
        private void CustomerSpeed_ValueChanged(Object sender, EventArgs e)
        {
            computerModel.CustomersSpeed = Convert.ToInt32(CustomerSpeed.Value);
        }
        private void CashBoxSpeed_ValueChanged(Object sender, EventArgs e)
        {
            computerModel.CashBoxSpeed = Convert.ToInt32(CashBoxSpeed.Value);
        }
    }
}
