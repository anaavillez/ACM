using System;
using System.Collections.Generic;
using Acme.Common;

namespace ACM.BL
{
    public class Customer : EntityBase, ILoggable
    {
        public Customer(): this (0)//use this to use first constructor to call the second
        {

        }

        public Customer(int customerId)
        {
            CustomerId = customerId;
            AddressList = new List<Address>();// need to be declared or it's null
        }

        public List<Address> AddressList { get; set; }
        public int CustomerId { get; private set; }
        public int CostumerType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAdress { get; set; }
        public string FullName
        {
            get
            {
                string fullName = LastName;
                if(!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(fullName))
                    {
                        fullName += ", ";
                    }
                    fullName += FirstName;
                }
                return fullName;
            }
        }

        public string Log() => $"{CustomerId}: {FullName} Email: {EmailAdress} Status: {EntityState.ToString()}";

        public static int InstanceCount { get; set; }

        public override string ToString() => FullName;

        ///<summary>
        ///Validates customer data.
        /// </summary>
        /// <returns> An InValid boolean</returns>
        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(EmailAdress)) isValid = false;

            return isValid;

        }

  
    }
}
