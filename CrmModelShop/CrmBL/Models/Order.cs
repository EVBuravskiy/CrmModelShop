namespace CrmBL.Models
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Идентификатор клиента для связи с таблицей покупателей
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Свойство связывающее с таблицей покупателя
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Идентификатор продавца для связи с таблицей продавцов
        /// </summary>
        public int SellerId { get; set; }

        /// <summary>
        /// Свойство связывающее с таблицей продавца
        /// </summary>
        public virtual Seller Seller { get; set; }

        /// <summary>
        /// Дата и время заказа
        /// </summary>
        public DateTime CreateOrderDateTime { get; set; }

        /// <summary>
        /// Свойство - коллекция связывающая с таблицей продажи
        /// </summary>
        public virtual ICollection<Sell> Sells { get; set; }

        public override string ToString()
        {
            return $"#{OrderId} from {CreateOrderDateTime.ToString("dd.MM.yy hh:mm:ss")}";
        }
    }
}
