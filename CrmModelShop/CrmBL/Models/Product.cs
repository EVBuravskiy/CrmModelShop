namespace CrmBL.Models
{
    /// <summary>
    /// Entity Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product ID
        /// </summary>
        public int ProductId { get; set; } 

        /// <summary>
        /// Product name
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// Product count
        /// </summary>
        public int ProductCount { get; set; }

        /// <summary>
        /// Collection of sells
        /// </summary>
        public virtual ICollection<Sell> Sells { get; set; }

        public override string ToString()
        {
            return $"{ProductName}\t\t{ProductPrice} руб.    \tОстаток: {ProductCount}";
        }

        /// <summary>
        /// Overridden compare method to use dictionary
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        public override bool Equals(object? obj)
        {
            if(obj is Product product)
            {
                return ProductId.Equals(product.ProductId);
            }
            return false;
        }

        /// <summary>
        /// Overridden method to get hashcode to use dictionary
        /// </summary>
        /// <returns>int</returns>
        public override int GetHashCode()
        {
            return ProductId;
        }
    }
}
