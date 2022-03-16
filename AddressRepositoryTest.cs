using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;


namespace ACM.BLTests
{
    [TestClass]
   public class AddressRepositoryTest
    {
        [TestMethod]
        public void RetrieveValidate()
        {
            var addressRepository = new AddressRepository();
            var expected = new Address(1)
            {
                AddressType = 1,
                StreetLine1 = "Bag end",
                StreetLine2 = "Bagshot row",
                City = "Hobbiton",
                State = "Shire",
                Country = "Middle Earth",
                PostalCode = "144",
            };

            var actual = addressRepository.Retreive(1);

            Assert.AreEqual(expected.AddressType, actual.AddressType);
            Assert.AreEqual(expected.AddressId, actual.AddressId);
            Assert.AreEqual(expected.StreetLine1, actual.StreetLine1);
            Assert.AreEqual(expected.StreetLine2, actual.StreetLine2);
            Assert.AreEqual(expected.City, actual.City);
            Assert.AreEqual(expected.State, actual.State);
            Assert.AreEqual(expected.Country, actual.Country);
            Assert.AreEqual(expected.PostalCode, actual.PostalCode);

        }

        [TestMethod]
        public void SaveSuccessful()
        {
            var addressRepository = new AddressRepository();
            var addressUpdated = new Address(1)
            {
                AddressType = 1,
                StreetLine1 = "Bag end",
                StreetLine2 = "Bagshot row",
                City = "HobbitShire",
                State = "Shire",
                Country = "Middle Earth",
                PostalCode = "144",
                HasChanges = true
            };

            var actual = addressRepository.Save(addressUpdated);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void SaveNotSuccessful()
        {
            var addressRepository = new AddressRepository();
            var addressUpdated = new Address(1)
            {
                AddressType = 1,
                StreetLine1 = "Bag end",
                StreetLine2 = "Bagshot row",
                City = "HobbitShire",
                State = "Shire",
                Country = "Middle Earth",
                PostalCode = null,
                HasChanges = true
            };

            var actual = addressRepository.Save(addressUpdated);

            Assert.AreEqual(false, actual);
        }
    }
}
