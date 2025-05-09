using System.Collections;

namespace CrmBL.Models
{
    public class Cart : IEnumerable
    {
        /// <summary>
        /// Свойство - для экземпляра класса Покупателя которому относится корзина
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Свойство - коллекция Товаров в виде словаря, где key - сам продукт, а value - их количество
        /// </summary>
        public Dictionary<Product, int> Products { get; set; }

        public Cart(Customer customer)
        {
            if (customer == null) throw new NullReferenceException($"Customer is null {nameof(customer)}");
            Customer = customer;
            Products = new Dictionary<Product, int>();
        }

        /// <summary>
        /// Метод добавления товара в корзину
        /// </summary>
        /// <param name="product"></param>
        public void AddToCart(Product product, int count = 1)
        {
            if (Products.ContainsKey(product))
            {
                Products[product] += count;
            }
            else Products.Add(product, count);
        }

        /// <summary>
        /// Метод удаления товара из корзины
        /// </summary>
        /// <param name="product"></param>
        public void RemoveFromCart(Product product) 
        { 
            if(Products.ContainsKey(product))
            {
                if (Products[product] > 1)
                {
                    Products[product] -= 1;
                    return;
                }
                if (Products[product] == 1)
                {
                    Products.Remove(product);
                    return;
                }
            }
            else
            {
                throw new ArgumentException("Product wasn't into cart");
            }
        }

        /// <summary>
        /// Метод получения всех товаров из корзины
        /// </summary>
        /// <returns>Список товаров</returns>
        public List<Product> GetAllFromCart()
        {
            List<Product> list = new List<Product>();
            foreach (Product product in Products.Keys)
            {
                for(int i = 0; i < Products[product]; i++)
                {
                    list.Add(product);
                }
            }
            return list;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var product in Products.Keys)
            {
                for (int i = 0; i < Products[product]; i++)
                {
                        yield return product;
                }
            };
        }
    }
}
