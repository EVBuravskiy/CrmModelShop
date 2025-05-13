using System.Collections;

namespace CrmBL.Models
{
    /// <summary>
    /// Cart Entity
    /// </summary>
    public class Cart : IEnumerable
    {
        /// <summary>
        /// Customer property
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Property collection(dictionary) of products
        /// </summary>
        public Dictionary<Product, int> Products { get; set; }

        /// <summary>
        /// Total Cost of products in cart
        /// </summary>
        public decimal TotalCost => GetAllFromCart().Sum(p => p.ProductPrice);

        /// <summary>
        /// Cart constructor
        /// </summary>
        /// <param name="customer"></param>
        /// <exception cref="NullReferenceException"></exception>
        public Cart(Customer customer)
        {
            if (customer == null) throw new NullReferenceException($"Customer is null {nameof(customer)}");
            Customer = customer;
            Products = new Dictionary<Product, int>();
        }

        /// <summary>
        /// Add to cart
        /// </summary>
        /// <param name="product"></param>
        public void AddToCart(Product product, int count = 1)
        {
            if (Products.ContainsKey(product))
            {
                Products[product] += count;
            }
            else
            {
                Products.Add(product, count);
            }
        }

        /// <summary>
        /// Remove from cart
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
        /// Get all products from cart
        /// </summary>
        /// <returns>List of products</returns>
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
