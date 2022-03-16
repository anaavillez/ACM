using System;
using System.Collections.Generic;
using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BLTests
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void RetrieveValid()
        {
            //Arrange
            var customerRepository = new CustomerRepository();
            var expected = new Customer(1)//1 is the id because it has a private setting
            {
                EmailAdress = "fbaggins@gmail.com",
                FirstName = "Frodo",
                LastName = "Baggins"
            };

            var actual = customerRepository.Retrieve(1);

            //Two different objects will never be equal so you have to compare the properties
            Assert.AreEqual(expected.CustomerId, actual.CustomerId);
            Assert.AreEqual(expected.EmailAdress, actual.EmailAdress);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
        }

        [TestMethod]
        public void RetrieveExistingWithAddress()
        {
            //Arrange
            var customerRepository = new CustomerRepository();
            var expected = new Customer(1)
            {
                EmailAdress = "fbaggins@gmail.com",
                FirstName = "Frodo",
                LastName = "Baggins",
                AddressList = new List<Address>()
                {
                    new Address()
                    {
                        AddressType = 1,
                        StreetLine1 = "Bag end",
                        StreetLine2 = "Bagshot row",
                        City = "Hobbiton",
                        State = "Shire",
                        Country = "Middle Earth",
                        PostalCode = "144",
                    },
                    new Address()
                    {
                          AddressType = 2,
                          StreetLine1 = "Manor Place",
                          StreetLine2 = "Grovesnor Yard",
                          City = "Newmarket",
                          State = "Suffolk",
                          Country = "England",
                          PostalCode = "CB8-9AW"
                    }


                }
            };

            var actual = customerRepository.Retrieve(1);

            Assert.AreEqual(expected.CustomerId, actual.CustomerId);
            Assert.AreEqual(expected.EmailAdress, actual.EmailAdress);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);

            for (int i = 0; i < 1; i++)
            {
                Assert.AreEqual(expected.AddressList[i].AddressType, actual.AddressList[i].AddressType);
                Assert.AreEqual(expected.AddressList[i].StreetLine1, actual.AddressList[i].StreetLine1);
                Assert.AreEqual(expected.AddressList[i].City, actual.AddressList[i].City);
                Assert.AreEqual(expected.AddressList[i].State, actual.AddressList[i].State);
                Assert.AreEqual(expected.AddressList[i].Country, actual.AddressList[i].Country);
                Assert.AreEqual(expected.AddressList[i].PostalCode, actual.AddressList[i].PostalCode);





            }

        }

        [TestMethod]
        public void SaveSucceful()
        {
            var customerRepository = new CustomerRepository();
            var updateCostumer = new Customer(1)
            {
                EmailAdress = "fbaggins@gmail.com",
                FirstName = "Bilbo",
                LastName = "Baggins",
                HasChanges = true
            };

            var actual = customerRepository.Save(updateCostumer);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void SaveNotSucceful()
        {
            var customerRepository = new CustomerRepository();
            var updateCostumer = new Customer(1)
            {
                EmailAdress = null,
                FirstName = "Bilbo",
                LastName = "Baggins",
                HasChanges = true
            };

            var actual = customerRepository.Save(updateCostumer);

            Assert.AreEqual(false, actual);
        }
    }
}
