namespace CrmBL.Models
{
    /// <summary>
    /// Generator of virtual objects(clients, products, cash registers) for computer modeling
    /// </summary>
    public class Generator
    {
        /// <summary>
        /// Price and quantity generator
        /// </summary>
        private Random rnd = new Random();

        /// <summary>
        /// Collection of customers
        /// </summary>
        public List<Customer> Customers { get; set; }

        /// <summary>
        /// Collection of products
        /// </summary>
        public List<Product> Products { get; set; }

        /// <summary>
        /// Collection of sellers
        /// </summary>
        public List<Seller> Sellers { get; set; }

        /// <summary>
        /// Generator constructor
        /// </summary>
        public Generator()
        {
            Customers = new List<Customer>();
            Products = new List<Product>();
            Sellers = new List<Seller>();
        }

        /// <summary>
        /// Create collection of customers
        /// </summary>
        /// <param name="count"></param>
        /// <returns>Collection of customers</returns>
        public List<Customer> GetNewCustomers(int count)
        {
            List<Customer> newCustomers = new List<Customer>();
            for(int i = 0; i < count; i++)
            {
                Customer newCustomer = new Customer()
                {
                    CustomerId = i + 1,
                    CustomerName = GetRandomText(),
                };
                newCustomers.Add(newCustomer);
                Customers.Add(newCustomer);
            }
            return newCustomers;
        }

        /// <summary>
        /// Create collection of sellers
        /// </summary>
        /// <param name="count"></param>
        /// <returns>Collection of sellers</returns>
        public List<Seller> GetNewSellers(int count)
        {
            List<Seller> newSellers = new List<Seller>();
            for (int i = 0; i < count; i++)
            {
                Seller newSeller = new Seller()
                {
                    SellerId = i + 1,
                    SellerName = GetRandomText(),
                };
                newSellers.Add(newSeller);
                Sellers.Add(newSeller);
            }
            return newSellers;
        }

        /// <summary>
        /// Create collection of products
        /// </summary>
        /// <param name="count"></param>
        /// <returns>Collection of products</returns>
        public List<Product> GetNewProducts(int count)
        {
            List<Product> newProducts = new List<Product>();
            for (int i = 0; i < count; i++)
            {
                Product newProduct = new Product()
                {
                    ProductId = i + 1,
                    ProductName = GetRandomText(),
                    ProductPrice = Convert.ToDecimal(rnd.Next(5, 100000) + rnd.NextDouble()),
                    ProductCount = rnd.Next(10, 1000),
                };
                newProducts.Add(newProduct);
                Products.Add(newProduct);
            }
            return newProducts;
        }

        /// <summary>
        /// Create random products with random price
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public List<Product> GetRandomProducts(int min, int max)
        {
            List<Product> listProducts = new List<Product>();
            int count = rnd.Next(min, max);
            for (int i = 0; i < count; i++)
            {
                listProducts.Add(Products[rnd.Next(Products.Count - 1)]);
            }
            return listProducts;
        }

        /// <summary>
        /// Get random text for customers, sellers and products
        /// </summary>
        /// <returns>Рандомный текст</returns>
        private string GetRandomText()
        {
            return Guid.NewGuid().ToString().Substring(0, 5);
        }
    }
}
