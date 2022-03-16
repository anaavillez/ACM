using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
   public class CustomerRepository
    {
        public CustomerRepository()
        {
            addressRepository = new AddressRepository();
        }
        private AddressRepository addressRepository { get; set; }

        public Customer Retrieve(int customerId)
        {
            //Create a new instance of the customer class
            //Pass in the requested id
            var customer = new Customer(customerId);

            //retrieving ID
            //Temporary hard-coded values
            if(customerId == 1)
            {
                customer.EmailAdress = "fbaggins@gmail.com";
                customer.FirstName = "Frodo";
                customer.LastName = "Baggins";
                customer.AddressList = addressRepository.RetrieveByCustomerId(customerId).ToList();
            }
            return customer;
        }

        public bool Save(Customer customer)
        {
            var success = true;

            if (customer.HasChanges)
            {
                if(customer.IsValid)
                {
                    if(customer.IsNew)
                    {
                        //Call an insert stored procedure
                    }
                    else
                    {
                        //call an insert update procedure
                    }
                }
                else
                {
                    success = false;
                }
            }

            return success;
        }
    }
}
