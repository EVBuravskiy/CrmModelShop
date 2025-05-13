using Microsoft.EntityFrameworkCore;

namespace CrmBL.Models
{
    public class CrmContext : DbContext
    {
        /// <summary>
        /// Entity clients
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Entity orders
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Entity products
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Intermediate entity of sale
        /// </summary>
        public DbSet<Sell> Sells { get; set; }

        /// <summary>
        /// Entity sellers
        /// </summary>
        public DbSet<Seller> Sellers { get; set; }


        /// <summary>
        /// Context constructor
        /// </summary>
        public CrmContext() : base()
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// OnConfiguring
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //The project used SqLite. The application was also tested on MSSQL
            //SqLite
            optionsBuilder.UseSqlite("Data Source = sqlightdb.db");
            //MSSQL
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=db; Database=crmdb; Integrated Security=True");
        }
    }
}
