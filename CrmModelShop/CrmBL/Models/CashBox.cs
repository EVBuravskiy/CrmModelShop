using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBL.Models
{
    /// <summary>
    /// Класс кассового аппарата выполняющий функции контроллера
    /// </summary>
    public class CashBox
    {
        /// <summary>
        /// Номер кассы
        /// </summary>
        public int CashBoxId { get; set; }

        /// <summary>
        /// Свойство - продавец
        /// </summary>
        public Seller Seller { get; set; }

        /// <summary>
        /// Свойство - очередь из корзин покупателей
        /// </summary>
        public Queue<Cart> CartsQueue { get; set; }

        /// <summary>
        /// Максимальная длина очереди
        /// </summary>
        public int MaxQueueLenght { get; set; }

        /// <summary>
        /// Текущая длина очереди
        /// </summary>
        public int CurrentQueueLength => CartsQueue.Count;


        /// <summary>
        /// Счетчик покупателей ушедших без покупки в случае большой очереди для компьютерного моделирования
        /// </summary>
        public int ExitCustomer { get; set; }

        /// <summary>
        /// Контекст для работы с базой данных
        /// </summary>
        public CrmContext CrmContext { get; set; }

        /// <summary>
        /// Флаг для компьютерного моделирования
        /// </summary>
        public bool IsModel { get; set; }

        /// <summary>
        /// Событие, возвращающее заказ
        /// </summary>
        public event EventHandler<Order> OrderClosedEvent;

        /// <summary>
        /// Конструктор инициализирующий касу
        /// </summary>
        /// <param name="cashBoxId"></param>
        /// <param name="seller"></param>
        
        public CashBox(int cashBoxId, Seller seller) 
        { 
            CashBoxId = cashBoxId;
            Seller = seller;
            CartsQueue = new Queue<Cart>();
            ExitCustomer = 0;
            CrmContext = new CrmContext();
            IsModel = true;
            MaxQueueLenght = 10;
        }



        /// <summary>
        /// Метод добавления корзины в очередь
        /// </summary>
        /// <param name="cart"></param>
        public void Enqueue(Cart cart)
        {
            if(CartsQueue.Count <= MaxQueueLenght)
            {
                CartsQueue.Enqueue(cart);
            }
            else
            {
                ExitCustomer++;
            }
        }

        /// <summary>
        /// Метод удаления корзины из очереди
        /// </summary>
        /// <returns>decimal - сумма покупки</returns>
        public decimal Dequeue()
        {
            decimal sum = 0;
            if (CartsQueue.Count == 0)
            {
                return sum;
            } 
            Cart cart = CartsQueue.Dequeue();
            if(cart != null)
            {
                Order order = new Order()
                {
                    SellerId = Seller.SellerId,
                    Seller = Seller,
                    CustomerId = cart.Customer.CustomerId,
                    Customer = cart.Customer,
                    CreateOrderDateTime = DateTime.Now,
                };
                if(!IsModel)
                {
                    CrmContext.Orders.Add(order);
                    CrmContext.SaveChanges();
                }
                else
                {
                    order.OrderId = 0;
                }
                List<Sell> sells = new List<Sell>();
                List<Product> products = cart.GetAllFromCart();
                foreach(Product product in products)
                {
                    if (product.ProductCount > 0)
                    {
                        Sell sell = new Sell()
                        {
                            OrderId = order.OrderId,
                            Order = order,
                            ProductId = product.ProductId,
                            Product = product,
                        };

                        sells.Add(sell);

                        if (!IsModel) 
                        {
                            CrmContext.Sells.Add(sell);
                        }

                        product.ProductCount -= 1;

                        sum += product.ProductPrice;
                    }
                }

                order.OrderPrice = sum;

                if (!IsModel) 
                {
                    CrmContext.SaveChanges();
                    return sum;
                }
                //Вызываем событие, куда передаем класс кассы - источник события, сформированный
                //заказ
                OrderClosedEvent?.Invoke(this, order); //Обязательно используем ? т.к. событие может вернуться равным null
            }
            return sum;
        }

        public override string ToString()
        {
            return $"Касса #{CashBoxId}";
        }

    }
}
