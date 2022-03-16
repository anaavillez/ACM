using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;

namespace ACM.BLTests
{
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public void RetrieveValid()
        {
            var productRepository = new ProductRepository();
            var expected = new Product(1)
            {
                ProductName = "Hammer",
                CurrentPrice = 15.99,
                ProductDescription = "Breaks things"
            };

            var actual = productRepository.Retrieve(1);

            Assert.AreEqual(expected.ProductDescription, actual.ProductDescription);
            Assert.AreEqual(expected.ProductName, actual.ProductName);
            Assert.AreEqual(expected.ProductId, actual.ProductId);
            Assert.AreEqual(expected.CurrentPrice, actual.CurrentPrice);
        }

        [TestMethod]
        public void SaveTestValid()
        {
            //Arrange
            var productRepository = new ProductRepository();
            var updateProduct = new Product(2)
            {
                CurrentPrice = 18.99,
                ProductDescription = "Used to build things and destroy things",
                ProductName = "Hammer",
                HasChanges = true
            };

            //Act
            var actual = productRepository.Save(updateProduct);

            //Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void SaveTestMissingPrice()
        {
            var productRepository = new ProductRepository();
            var updateProduct = new Product(2)
            {
                CurrentPrice = null,
                ProductDescription = "builds things",
                ProductName = " Hammer",
                HasChanges = true
            };

            var actual = productRepository.Save(updateProduct);

            Assert.AreEqual(false, actual);
        }
    }
}

