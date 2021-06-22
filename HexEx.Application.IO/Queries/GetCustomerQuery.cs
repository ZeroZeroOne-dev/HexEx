using System;
using HexEx.Application.IO.Reponses;
using MediatR;

namespace HexEx.Application.IO.Queries {
    public class GetCustomerQuery: IRequest<GetCustomerQueryResponse>{
        public Guid Id { get; set; }
    }
}