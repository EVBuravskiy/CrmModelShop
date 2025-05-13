namespace CrmBL.Models
{
    /// <summary>
    /// Entity Customer
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Customer ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Customer name
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Collection of orders
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }    

        public override string ToString()
        {
            return CustomerName;
        }
    }
}
