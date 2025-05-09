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

        /// <summary>
        /// Переопределенный метод сравнения для использования словаря
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if(obj is Product product)
            {
                return ProductId.Equals(product.ProductId);
            }
            return false;
        }

        /// <summary>
        /// Переопределенный метод получения хеш-кода для использования словаря
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ProductId;
        }
    }
}
