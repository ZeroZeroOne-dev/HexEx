using System.Threading;
using System.Threading.Tasks;
using HexEx.Application.IO.Commands;
using HexEx.Application.IO.Reponses;
using MediatR;

namespace HexEx.Application.CommandHandlers
{
    public class SetPostalCodeCommandHandler : IRequestHandler<SetPostalCodeCommand, GetCustomerQueryResponse>
    {
        private readonly ICustomerRepository customerRepository;

        public SetPostalCodeCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<GetCustomerQueryResponse> Handle(SetPostalCodeCommand request, CancellationToken cancellationToken)
        {
            var customer = await this.customerRepository.Get(request.Id, cancellationToken);

            customer.PostalCode = request.PostalCode;

            var updated = await this.customerRepository.Save(customer, cancellationToken);

            return new GetCustomerQueryResponse
            {
                Id = updated.Id,
                Name = updated.Name,
                PostalCode = updated.PostalCode
            };
        }
    }
}