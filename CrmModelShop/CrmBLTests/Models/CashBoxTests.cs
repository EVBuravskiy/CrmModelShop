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
    public class CashBoxTests
    {
        [TestMethod()]
        public void CashBoxTest()
        {
            //Arrange
            Customer customer1 = new Customer()
            {
                CustomerId = 1,
                CustomerName = "TestCustomer1",
            };

            Customer customer2 = new Customer()
            {
                CustomerId = 2,
                CustomerName = "TestCustomer2",
            };

            Seller seller = new Seller()
            {
                SellerId = 1,
                SellerName = "TestSeller",
            };

            Product product1 = new Product() { ProductId = 1, ProductName = "product1", ProductPrice = 100, ProductCount = 10 };
            Product product2 = new Product() { ProductId = 2, ProductName = "product2", ProductPrice = 200, ProductCount = 20 };

            Cart cartCustomer1 = new Cart(customer1);
            Cart cartCustomer2 = new Cart(customer2);


            cartCustomer1.AddToCart(product1);
            cartCustomer1.AddToCart(product1);
            cartCustomer1.AddToCart(product2);

            cartCustomer2.AddToCart(product1);
            cartCustomer2.AddToCart(product2);
            cartCustomer2.AddToCart(product2);

            CashBox cashBox = new CashBox(1, seller);

            cashBox.Enqueue(cartCustomer1);
            cashBox.Enqueue(cartCustomer2);

            decimal firstExpectedResult = 400;
            decimal secondExpectedResult = 500;

            //Act
            decimal firstResult = cashBox.Dequeue();
            decimal secondResult = cashBox.Dequeue();   

            //Assert
            Assert.AreEqual(firstExpectedResult, firstResult);
            Assert.AreEqual(secondExpectedResult, secondResult);
            Assert.AreEqual(7, product1.ProductCount);
            Assert.AreEqual(17, product2.ProductCount);
        }
    }
}