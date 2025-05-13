using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBL.Models
{
    /// <summary>
    /// Cashbox class implementing the controller 
    /// </summary>
    public class CashBox
    {
        /// <summary>
        /// Сashbox ID
        /// </summary>
        public int CashBoxId { get; set; }

        /// <summary>
        /// Property seller
        /// </summary>
        public Seller Seller { get; set; }

        /// <summary>
        /// Property queue of customer baskets
        /// </summary>
        public Queue<Cart> CartsQueue { get; set; }

        /// <summary>
        /// Maximum queue length for computer simulation
        /// </summary>
        public int MaxQueueLenght { get; set; }

        /// <summary>
        /// Current queue length for computer simulation
        /// </summary>
        public int CurrentQueueLength => CartsQueue.Count;


        /// <summary>
        /// Abandoned customer counter for computer simulation
        /// </summary>
        public int ExitCustomer { get; set; }

        /// <summary>
        /// Database context
        /// </summary>
        public CrmContext CrmContext { get; set; }

        /// <summary>
        /// Pointer for computer simulation
        /// </summary>
        public bool IsModel { get; set; }

        /// <summary>
        /// Event returning an order
        /// </summary>
        public event EventHandler<Order> OrderClosedEvent;

        /// <summary>
        /// Cashbox constructor
        /// </summary>
        /// <param name="cashBoxId"></param>
        /// <param name="seller"></param>
        /// <param name="crmContext"></param>
        public CashBox(int cashBoxId, Seller seller, CrmContext crmContext = null) 
        { 
            CashBoxId = cashBoxId;
            Seller = seller;
            CartsQueue = new Queue<Cart>();
            ExitCustomer = 0;
            CrmContext = crmContext ?? new CrmContext();
            IsModel = true;
            MaxQueueLenght = 10;
        }



        /// <summary>
        /// Adding a customer's cart to the queue
        /// </summary>
        /// <param name="cart"></param>
        public void Enqueue(Cart cart)
        {
            if(CartsQueue.Count < MaxQueueLenght)
            {
                CartsQueue.Enqueue(cart);
            }
            else
            {
                ExitCustomer++;
            }
        }

        /// <summary>
        /// Removing a customer's cart from the queue
        /// </summary>
        /// <returns>decimal - Purchase amount</returns>
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
                    OrderPrice = cart.TotalCost,
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

                        sum += product.ProductPrice;
                    }
                }

                order.OrderPrice = sum;

                if (!IsModel) 
                {
                    CrmContext.SaveChanges();
                    return sum;
                }
                OrderClosedEvent?.Invoke(this, order);
            }
            return sum;
        }

        public override string ToString()
        {
            return $"Касса #{CashBoxId}";
        }
    }
}
