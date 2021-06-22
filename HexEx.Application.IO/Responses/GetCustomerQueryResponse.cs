using System;

namespace HexEx.Application.IO.Reponses
{
    public class GetCustomerQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PostalCode { get; set; }
    }
}