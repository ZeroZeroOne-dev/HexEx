using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HexEx.Domain;
using HexEx.Infrastucture.Models;

namespace HexEx.Infrastucture.Repositories
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private List<DbCustomer> data = new List<DbCustomer>();

        public Task<Customer> Get(Guid Id, CancellationToken cancellationToken)
        {
            var dbCustomer = data.First(c => c.Id == Id).MapOut();

            return Task.FromResult(dbCustomer);
        }

        public Task<Customer> Save(Customer customer, CancellationToken cancellationToken)
        {
            var dbCustomer = DbCustomer.MapIn(customer);
            dbCustomer.UpdateDate = DateTime.Now;

            if (dbCustomer.Id == Guid.Empty)
            {
                dbCustomer.Id = Guid.NewGuid();
            }
            else
            {
                data.RemoveAll(c => c.Id == customer.Id);
            }

            data.Add(dbCustomer);

            return Task.FromResult(dbCustomer.MapOut());
        }
    }
}