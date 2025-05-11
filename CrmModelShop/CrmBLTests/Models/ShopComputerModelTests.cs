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
    public class ShopComputerModelTests
    {
        [TestMethod()]
        public void StartTest()
        {
            //Arrage
            ShopComputerModel shopComputerModel = new ShopComputerModel();
            shopComputerModel.Start();
            Thread.Sleep(10000);
            shopComputerModel.Stop();
            //Act

            //Assert
        }
    }
}