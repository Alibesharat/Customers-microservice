using System;

namespace Entites
{
    //TODO : All attributes are required.
    public class Customer
    {
        public Customer()
        {

        }


        //TODO :Must be Uniq
        public string Email { get; set; }


        public Address Address { get; set; }

        //TODO :Must be UTC DateTime
        public DateTime CreatedAt { get; set; }


        public bool IsArchived { get; set; }

        //TODO :Must be UTC DateTime

        public DateTime PurchasedAt { get; set; }



    }
}
