using NUnit.Framework;
using SeleniumNUnitExtentNopCommerce.Pages;
using SeleniumNUnitExtentNopCommerce.Setups;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SeleniumNUnitExtentNopCommerce.Tests
{
    [TestFixture]
    public class ComputerTest:DriverExtentHook
    {
        [Test]
        [Category("Integration")]
        public void OrderNotebookVerifyTotal()
        {
           string ProductName = InitPages.computersPage.OrderNotebook();
            Assert.AreEqual("Apple MacBook Pro 13-inch", ProductName);
        }
    }
}
