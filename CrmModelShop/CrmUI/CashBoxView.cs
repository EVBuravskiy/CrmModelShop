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
        /// Property Cashbox
        /// </summary>
        public CashBox CashBox { get; set; }

        /// <summary>
        /// Label CashBoxName for form
        /// </summary>
        public Label CashBoxName { get; set; }

        /// <summary>
        /// Property Price
        /// </summary>
        public NumericUpDown Price { get; set; }

        /// <summary>
        /// Queue length property for progressbar
        /// </summary>
        public ProgressBar QueueLenght { get; set; }

        /// <summary>
        /// Property number of customers who was left
        /// </summary>
        public Label LeaveCustomersCount { get; set; }

        /// <summary>
        /// Cashbox view constructor
        /// </summary>
        /// <param name="cashBox"></param>
        /// <param name="number"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public CashBoxView(CashBox cashBox, int number, int x, int y) 
        {
            CashBox = cashBox;
            CashBoxName = new Label();
            CashBoxName.AutoSize = true;
            CashBoxName.Location = new System.Drawing.Point(x, y);    
            CashBoxName.Name = "CashBoxName" + number;                
            CashBoxName.Size = new System.Drawing.Size(40, 23);       
            CashBoxName.TabIndex = 1;                                 
            CashBoxName.Text = CashBox.ToString();                    

            Price = new NumericUpDown();
            Price.DecimalPlaces = 2;
            Price.Location = new System.Drawing.Point(x + 70, y);    
            Price.Maximum = new decimal(new int[] {
                    1000000000,
                    0,
                    0,
                    0});
            Price.Name = "Price" + number;                          
            Price.Size = new System.Drawing.Size(100, 23);          
            Price.TabIndex = 1;

            QueueLenght = new ProgressBar();
            QueueLenght.Enabled = false;
            QueueLenght.Location = new System.Drawing.Point(x + 170, y);
            QueueLenght.Name = "QueueLenght" + number;
            QueueLenght.Size = new System.Drawing.Size(200, 23);
            QueueLenght.Maximum = CashBox.MaxQueueLenght;
            QueueLenght.TabIndex = 1;
            QueueLenght.Value = 0;

            LeaveCustomersCount = new Label();
            LeaveCustomersCount.AutoSize = true;
            LeaveCustomersCount.Location = new System.Drawing.Point(x+400, y);//расположение элемента на форме
            LeaveCustomersCount.Name = "lostCustomers" + number;             //имя элемента на форме
            LeaveCustomersCount.Size = new System.Drawing.Size(40, 15);       //размеры элемента на форме
            LeaveCustomersCount.TabIndex = 1;                                 //индекс отступа
            LeaveCustomersCount.Text = "";                                    //отображаемый текст элемента


            //Event from CashBox
            CashBox.OrderClosedEvent += OrderBox_OrderClosed;
        }

        /// <summary>
        /// Change of form when an event occurs
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
