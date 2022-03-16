using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM;
using ACM.BL;

namespace CustomerTests
{
    [TestClass]
    public class ACMBLTests
    {
        [TestMethod]
       public void FullNameTestValid()
        {
            //Arrange
            Customer customer = new Customer
            {
               FirstName = "Ana",
               LastName = "Avillez"
            };
            string expected = "Avillez, Ana";

            //Act
            string actual = customer.FullName;

            //Assert
            Assert.AreEqual(expected, actual); 
        }

        [TestMethod]
        public void FullNameFirstNameEmpty()
        {
            //Arrange 
            Customer customer = new Customer
            {
                LastName = "Avillez"
            };
            string expected = "Avillez";

            //Act
            string actual = customer.FullName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            //Arrange 
            Customer customer = new Customer
            {
                FirstName = "Ana"
            };
            string expected = "Ana";

            //Act
            string actual = customer.FullName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StaticTest()
        {
            //Arrange
            var c1 = new Customer();
            c1.FirstName = "Ana";
            Customer.InstanceCount += 1;

            var c2 = new Customer();
            c2.FirstName = "Frodo";
            Customer.InstanceCount += 1;

            var c3 = new Customer();
            c3.FirstName = "Bilbo";
            Customer.InstanceCount += 1;

            //Act


            //Assert
            Assert.AreEqual(3, Customer.InstanceCount);
        }

        [TestMethod]
        public void ValidateValid()
        {
            //Arrange
            var customer = new Customer
            {
                LastName = "Baggins",
                EmailAdress = "fbaggins@gmail.com"
            };

            var expected = true;

            //Act
            var actual = customer.Validate();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Missing a LastName.")]
        public void ValidateMissingLastName()
        {
            var customer = new Customer
            {
                EmailAdress = "fbaggins@gmail.com"
            };

            var expected = false;

            var actual = customer.Validate();

            Assert.AreEqual(expected, actual);
        }

       
    }

   
    
}
