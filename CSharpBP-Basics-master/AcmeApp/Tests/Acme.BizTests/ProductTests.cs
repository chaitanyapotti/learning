using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            //Arrange
            Product currentProduct = new Product();
            currentProduct.ProductName = "Saw";
            currentProduct.ProductId = 1;
            //currentProduct.ProductVendor.CompanyName = "ABC Corp";
            var companyName = currentProduct?.ProductVendor?.CompanyName;
            Console.WriteLine(companyName);
            currentProduct.Description = "15 inch steel blade hand saw";
            string expected = "Hello Saw (1): 15 inch steel blade hand saw";
            //Act
            var actual = currentProduct.SayHello();
            //Asserts
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SayHelloparameterizedConstructor()
        {
            //Arrange
            Product currentProduct = new Product(1,"Saw", "15 inch steel blade hand saw");
            
            string expected = "Hello Saw (1): 15 inch steel blade hand saw";
            //Act
            var actual = currentProduct.SayHello();
            //Asserts
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void SayHello_ObjectInitializer()
        {
            DateTime? vavr = null;

            //Arrange
            Product currentProduct = new Product
            {
                ProductId = 1,
                ProductName = "Saw",
                Description = "15 inch steel blade hand saw"
            };
            string expected = "Hello Saw (1): 15 inch steel blade hand saw";
            //Act
            var actual = currentProduct.SayHello();
            //Asserts
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Product_Null()
        {
            
            //Arrange
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;
            string expected = null;
            //Act
            var actual = companyName;
            //Asserts
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringComparision()
        {
            string str1 = "hello";
            string str2 = "Hello";
            bool actual = (str1.Equals(str2, StringComparison.OrdinalIgnoreCase));
            var expected = true;
            Assert.AreEqual(expected, actual);
        }
    }
}