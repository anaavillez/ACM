using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;

namespace ACM.BLTests
{
    [TestClass]
    public class OrderRepositoryTest
    {
        [TestMethod]
        public void RetrieveValid()
        {
            var order = new OrderRepository();

            var expected = new Order(10)
            {
                OrderDate = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0))
            };

            var actual = order.Retrieve(10);

            Assert.AreEqual(expected.OrderDate, actual.OrderDate);
        }

        [TestMethod]
        public void SaveSuccessful()
        {
            var orderRepository = new OrderRepository();
            var updatedOrder = new Order(10)
            {
                OrderDate = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7, 1, 0)),
                HasChanges = true
            };

            var actual = orderRepository.Save(updatedOrder);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void SaveNotSuccessful()
        {
            var orderRepository = new OrderRepository();
            var updatedOrder = new Order(10)
            {
                OrderDate = null,
                HasChanges = true
            };

            var actual = orderRepository.Save(updatedOrder);

            Assert.AreEqual(false, actual);
        }
    }
}
