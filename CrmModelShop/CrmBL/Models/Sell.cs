namespace CrmBL.Models
{
    /// <summary>
    /// Sell ​​intermediate entity for orders and products
    /// </summary>
    public class Sell
    {
        /// <summary>
        /// Sell ID
        /// </summary>
        public int SellId { get; set; }

        /// <summary>
        /// Order ID
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Entity Order
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// Product ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Entity Product
        /// </summary>
        public Product Product { get; set; }
    }
}
