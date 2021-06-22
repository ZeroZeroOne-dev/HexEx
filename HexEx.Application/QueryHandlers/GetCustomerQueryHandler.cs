using System.Threading;
using System.Threading.Tasks;
using HexEx.Application.IO.Queries;
using HexEx.Application.IO.Reponses;
using MediatR;

namespace HexEx.Application.QueryHandlers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerQueryResponse>
    {
        private readonly ICustomerRepository customerRepository;

        public GetCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<GetCustomerQueryResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await this.customerRepository.Get(request.Id, cancellationToken);

            return new GetCustomerQueryResponse{
                Id = customer.Id,
                Name = customer.Name,
                PostalCode = customer.PostalCode
            };
        }
    }
}