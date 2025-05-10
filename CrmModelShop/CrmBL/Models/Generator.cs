namespace CrmBL.Models
{
    /// <summary>
    /// Класс для генерации виртуальных объектов для компьютерного моделирования
    /// </summary>
    public class Generator
    {
        /// <summary>
        /// Генератор для создания цен и количества
        /// </summary>
        private Random rnd = new Random();

        /// <summary>
        /// Коллекция клиентов
        /// </summary>
        public List<Customer> Customers { get; set; }

        /// <summary>
        /// Коллекция товаров
        /// </summary>
        public List<Product> Products { get; set; }

        /// <summary>
        /// Коллекция продавцов
        /// </summary>
        public List<Seller> Sellers { get; set; }

        public Generator()
        {
            Customers = new List<Customer>();
            Products = new List<Product>();
            Sellers = new List<Seller>();
        }

        /// <summary>
        /// Метод для создания коллекции заданного количества клиентов
        /// </summary>
        /// <param name="count"></param>
        /// <returns>Коллекция клиентов</returns>
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
        /// Метод для создания коллекции заданного количества продавцов
        /// </summary>
        /// <param name="count"></param>
        /// <returns>Коллекция продавцов</returns>
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
        /// Метод для создания коллекции заданного количества товаров
        /// </summary>
        /// <param name="count"></param>
        /// <returns>Коллекция товаров</returns>
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
        /// Метод для создания коллекции рандомных продуктов
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
        /// Приватный метод для создания рандомного текста
        /// </summary>
        /// <returns>Рандомный текст</returns>
        private string GetRandomText()
        {
            return Guid.NewGuid().ToString().Substring(0, 5);
        }
    }
}
