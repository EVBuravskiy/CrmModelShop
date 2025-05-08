namespace CrmBL.Models
{
    /// <summary>
    /// Таблица связывающая заказ и продукты
    /// </summary>
    public class Sell
    {
        /// <summary>
        /// Идентификатор продажи
        /// </summary>
        public int SellId { get; set; }

        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Свойство связывающее с таблицей заказа
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Свойство связывающее с таблицей продукта
        /// </summary>
        public Product Product { get; set; }
        //<connectionStrings>
        //<add name="DBContection" connectionString="Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=db; Integrated Security=True" providerName="System.Data.SqlClient"/>
        //</connectionStrings>
    }
}
