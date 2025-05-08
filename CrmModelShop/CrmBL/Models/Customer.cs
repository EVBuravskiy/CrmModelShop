namespace CrmBL.Models
{
    /// <summary>
    /// Клиент - покупатель
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Идентификатор клиента для базы данных
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Имя клиента
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Свойство - коллекция связанное с заказами
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }    

        public override string ToString()
        {
            return CustomerName;
        }
    }
}
