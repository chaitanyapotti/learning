﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorTests
    {
        [TestMethod()]
        public void SendWelcomeEmail_ValidCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "ABC Corp";
            var expected = "Message sent: Hello ABC Corp";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_EmptyCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "";
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_NullCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = null;
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PlaceOrderTest()
        {
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = true;
            //Act
            var actual = vendor.PlaceOrder(product, 12);
            //vendor.PlaceOrder(product, quantity: 1, deliverBy: new DateTimeOffset(2017,1,1,1,1,1));
            Assert.AreEqual(expected, actual.Success);
            //Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceOrder_NullProduct_Exception()
        {
            var vendor = new Vendor();
            //var product = null;
            var expected = true;

            //Act
            var actual = vendor.PlaceOrder(null, 12);

            Assert.AreEqual(expected, actual);
            //Assert.Fail();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var vendor = new Vendor { CompanyName = "ABC Corp", VendorId = 1 };
            var expected = "Vendor: ABC Corp";
            var actual = vendor.ToString();
            Assert.AreEqual(expected, actual);
            //Assert.Fail();
        }
    }
}