using System;
using System.Threading;
using System.Threading.Tasks;
using HexEx.Domain;
public interface ICustomerRepository {
    Task<Customer> Get(Guid Id, CancellationToken cancellationToken);
    Task<Customer> Save(Customer customer, CancellationToken cancellationToken);
}