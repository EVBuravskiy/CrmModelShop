namespace CrmBL.Models
{
    /// <summary>
    /// Продавец
    /// </summary>
    public class Seller
    {
        /// <summary>
        /// Идентификатор продавца для базы данных
        /// </summary>
        public int SellerId { get; set; }

        /// <summary>
        /// Имя продавца
        /// </summary>
        public string SellerName { get; set; }

        /// <summary>
        /// Свойство - коллекция связанная с заказами
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }

        public override string ToString()
        {
            return SellerName;
        }
    }
}
