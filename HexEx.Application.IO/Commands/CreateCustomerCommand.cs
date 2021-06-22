using HexEx.Application.IO.Reponses;
using MediatR;

namespace HexEx.Application.IO.Commands {

    public class CreateCustomerCommand : IRequest<CreateCustomerCommandResponse> {
        public string Name { get; set; }
    }

}