namespace CrmBL.Models
{
    /// <summary>
    /// Entity Order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Order ID
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Customer ID for Entity
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Property Customer for Entity
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Seller ID for Entity
        /// </summary>
        public int SellerId { get; set; }

        /// <summary>
        /// Property Seller for Entity
        /// </summary>
        public virtual Seller Seller { get; set; }

        /// <summary>
        /// Date and time of order formation
        /// </summary>
        public DateTime CreateOrderDateTime { get; set; }

        /// <summary>
        /// Collection of Sells
        /// </summary>
        public virtual ICollection<Sell> Sells { get; set; }

        /// <summary>
        /// Total price of order
        /// </summary>
        public decimal OrderPrice { get; set; }

        public override string ToString()
        {
            return $"#{OrderId} from {CreateOrderDateTime.ToString("dd.MM.yy hh:mm:ss")}";
        }
    }
}
