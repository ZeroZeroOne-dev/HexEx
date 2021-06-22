using System;
using HexEx.Application.IO.Reponses;
using MediatR;

namespace HexEx.Application.IO.Commands {

    public class SetPostalCodeCommand : IRequest<GetCustomerQueryResponse> {
        public Guid Id { get; set; }
        public string PostalCode { get; set; }
    }

}