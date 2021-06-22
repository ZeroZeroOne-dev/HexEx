using System.Threading;
using System.Threading.Tasks;
using HexEx.Application.IO.Commands;
using HexEx.Application.IO.Reponses;
using HexEx.Domain;
using MediatR;

namespace HexEx.Application.CommandHandlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        private readonly ICustomerRepository customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Name = request.Name,
            };

            var saved = await this.customerRepository.Save(customer, cancellationToken);

            return new CreateCustomerCommandResponse
            {
                Id = saved.Id,
                Name = saved.Name
            };
        }
    }
}