using Microsoft.EntityFrameworkCore;

namespace CrmBL.Models
{
    public class CrmContext : DbContext
    {
        /// <summary>
        /// Свойство-таблица клиентов в базе данных
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Свойство-таблица заказов в базе данных
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Свойство-таблица товаров в базе данных
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Свойство-промежуточная таблица продаж в базе данных
        /// </summary>
        public DbSet<Sell> Sells { get; set; }

        /// <summary>
        /// Свойство-таблица продавцов (кассиров) в базе данных
        /// </summary>
        public DbSet<Seller> Sellers { get; set; }



        /// <summary>
        /// Конструктор CrmContext
        /// </summary>
        public CrmContext() : base()
        {
            //Открывает базу данных, при ее отсутствии создает ее
            Database.EnsureCreated();
        }

        /// <summary>
        /// Переопределенный метод OnConfiguring содержащий конфигурацию подключения к базе данных
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=crmdb; Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=db; Database=crmdb; Integrated Security=True");
            //optionsBuilder.UseSqlite("Data Source = sqlightdb.db");
        }
    }
}
