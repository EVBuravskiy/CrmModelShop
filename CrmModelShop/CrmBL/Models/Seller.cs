namespace CrmBL.Models
{
    /// <summary>
    /// Entity Seller
    /// </summary>
    public class Seller
    {
        /// <summary>
        /// Seller ID
        /// </summary>
        public int SellerId { get; set; }

        /// <summary>
        /// Seller name
        /// </summary>
        public string SellerName { get; set; }

        /// <summary>
        /// Collection of orders
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }

        public override string ToString()
        {
            return SellerName;
        }
    }
}
