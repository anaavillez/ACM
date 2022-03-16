using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
   public class AddressRepository
    {
        public Address Retreive(int addressId)
        {
            Address address = new Address(addressId);

            if(addressId == 1)
            {
                address.AddressType = 1;
                address.StreetLine1 = "Bag end";
                address.StreetLine2 = "Bagshot row";
                address.City = "Hobbiton";
                address.State = "Shire";
                address.Country = "Middle Earth";
                address.PostalCode = "144";
            }

            return address;
        }

        public IEnumerable<Address> RetrieveByCustomerId(int customerId)
        {
            var addressList = new List<Address>();
            Address address = new Address(1)
            {
                AddressType = 1,
                StreetLine1 = "Bag end",
                StreetLine2 = "Bagshot row",
                City = "Hobbiton",
                State = "Shire",
                Country = "Middle Earth",
                PostalCode = "144",
            };
            addressList.Add(address);

            address = new Address(2)
            {
                AddressType = 2,
                StreetLine1 = "Manor Place",
                StreetLine2 = "Grovesnor Yard",
                City = "Newmarket",
                State = "Suffolk",
                Country = "England",
                PostalCode = "CB8-9AW"
            };

            addressList.Add(address);

            return addressList;
        }

      public bool Save(Address address)
        {
            var success = true;

            if(address.HasChanges)
            {
                if(address.IsValid)
                {
                    if(address.IsNew)
                    {
                        //Call an insert store procedure
                    }
                    else
                    {
                        //Call an insert update procedure
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
