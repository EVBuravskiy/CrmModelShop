using CrmBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmUI
{
    public class CashBoxView
    {
        /// <summary>
        /// Свойство кассы
        /// </summary>
        public CashBox CashBox { get; set; }

        /// <summary>
        /// Свойство CashBoxName для формы
        /// </summary>
        public Label CashBoxName { get; set; }

        /// <summary>
        /// Свойство Price для формы
        /// </summary>
        public NumericUpDown Price { get; set; }

        /// <summary>
        /// Свойство QueueLenght для формы
        /// </summary>
        public ProgressBar QueueLenght { get; set; }

        /// <summary>
        /// Свойство LeaveCustomersCount для формы
        /// </summary>
        public Label LeaveCustomersCount { get; set; }

        /// <summary>
        /// Создаем конструктор, в который передаем саму кассу, выручку, и расположение элемента по оси x и y
        /// </summary>
        /// <param name="cashBox"></param>
        /// <param name="number"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public CashBoxView(CashBox cashBox, int number, int x, int y) 
        {
            CashBox = cashBox;

            //Создаем CashBoxName и заполняем его свойствами
            CashBoxName = new Label();
            CashBoxName.AutoSize = true;
            CashBoxName.Location = new System.Drawing.Point(x, y);    //расположение элемента на форме
            CashBoxName.Name = "CashBoxName" + number;                //имя элемента на форме
            CashBoxName.Size = new System.Drawing.Size(40, 23);       //размеры элемента на форме
            CashBoxName.TabIndex = 1;                                 //индекс отступа
            CashBoxName.Text = CashBox.ToString();                    //отображаемый текст элемента

            //Создаем Price и заполняем его свойствами
            Price = new NumericUpDown();
            Price.DecimalPlaces = 2;
            Price.Location = new System.Drawing.Point(x + 70, y);    //расположение элемента на форме
            Price.Maximum = new decimal(new int[] {
                    1000000000,
                    0,
                    0,
                    0});
            Price.Name = "Price" + number;                          //имя элемента на форме
            Price.Size = new System.Drawing.Size(100, 23);          //размеры элемента на форме
            Price.TabIndex = 1;

            //Создаем QueueLenght
            QueueLenght = new ProgressBar();
            QueueLenght.Enabled = false;
            QueueLenght.Location = new System.Drawing.Point(x + 170, y);
            QueueLenght.Name = "QueueLenght" + number;
            QueueLenght.Size = new System.Drawing.Size(200, 23);
            QueueLenght.Maximum = CashBox.MaxQueueLenght;
            QueueLenght.TabIndex = 1;
            QueueLenght.Value = 0;

            //Создаем LeaveCustomersCount и заполняем его свойствами
            LeaveCustomersCount = new Label();
            LeaveCustomersCount.AutoSize = true;
            LeaveCustomersCount.Location = new System.Drawing.Point(x+400, y);//расположение элемента на форме
            LeaveCustomersCount.Name = "lostCustomers" + number;             //имя элемента на форме
            LeaveCustomersCount.Size = new System.Drawing.Size(40, 15);       //размеры элемента на форме
            LeaveCustomersCount.TabIndex = 1;                                 //индекс отступа
            LeaveCustomersCount.Text = "";                                    //отображаемый текст элемента


            //Подписываемся на событие в CashBox
            CashBox.OrderClosedEvent += OrderBox_OrderClosed;
        }

        /// <summary>
        /// Приватный метод реализующий появление события
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="order"></param>
        private void OrderBox_OrderClosed(object sender, Order order)
        {
            Price.Invoke((Action)delegate { Price.Value += order.OrderPrice; });
            QueueLenght.Invoke((Action)delegate { QueueLenght.Value = CashBox.CurrentQueueLength; });
            LeaveCustomersCount.Invoke((Action)delegate { LeaveCustomersCount.Text = CashBox.ExitCustomer.ToString(); });
        }
    }
}
