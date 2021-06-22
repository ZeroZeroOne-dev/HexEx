using System;
using HexEx.Domain;

namespace HexEx.Infrastucture.Models
{

    public class DbCustomer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string PostalCode { get; set; }

        public DateTime UpdateDate { get; set; }

        public Customer MapOut()
        {
            return new Customer
            {
                Id = this.Id,
                Name = this.Name,
                PostalCode = this.PostalCode
            };
        }

        public static DbCustomer MapIn(Customer domainCustomer)
        {
            return new DbCustomer
            {
                Id = domainCustomer.Id,
                Name = domainCustomer.Name,
                PostalCode = domainCustomer.PostalCode
            };
        }
    }
}