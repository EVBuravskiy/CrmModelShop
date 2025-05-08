namespace CrmBL.Models
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Идентификатор продукта в базе данных для Entity Framework
        /// </summary>
        public int ProductId { get; set; } 

        /// <summary>
        /// Имя продукта
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Цена продукта
        /// </summary>
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// Количество продукта
        /// </summary>
        public int ProductCount { get; set; }

        /// <summary>
        /// Свойство - коллекция связывающая с таблицей продажи
        /// </summary>
        public virtual ICollection<Sell> Sells { get; set; }

        public override string ToString()
        {
            return ProductName;
        }
    }
}
