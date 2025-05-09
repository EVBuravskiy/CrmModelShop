using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBL.Models.Tests
{
    [TestClass()]
    public class CartTests
    {
        //Arrange 
        Customer customer = new Customer() { CustomerName = "testUser" };
        Product product1 = new Product() { ProductId = 1, ProductName = "product1", ProductPrice = 100, ProductCount = 1 };
        Product product2 = new Product() { ProductId = 2, ProductName = "product2", ProductPrice = 200, ProductCount = 5 };
        Cart cart;

        [TestMethod()]
        public void AddToCartTest()
        {
            //Arrange 
            cart = new Cart(customer);
            List<Product> expectedResult = new List<Product>()
            {
                product1, product1, product2,
            };

            //Act
            cart.AddToCart(product1);
            cart.AddToCart(product1);
            cart.AddToCart(product2);

            List<Product> cartResult = cart.GetAllFromCart();

            //Assert
            Assert.AreEqual(expectedResult.Count, cartResult.Count);
            for(int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].ProductName, cartResult[i].ProductName);
            }
        }
        [TestMethod()]
        public void RemoveFromCartTest()
        {
            //Arrange 
            customer = new Customer() { CustomerName = "testUser" };
            Cart cart = new Cart(customer);
            List<Product> expectedResult = new List<Product>()
            {
                product1, 
            };

            //Act
            cart.AddToCart(product1);
            cart.AddToCart(product1);
            cart.AddToCart(product2);

            cart.RemoveFromCart(product1);
            cart.RemoveFromCart(product2);

            List<Product> cartResult = cart.GetAllFromCart();

            //Assert
            Assert.AreEqual(expectedResult.Count, cartResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].ProductName, cartResult[i].ProductName);
            }
        }

    }
}