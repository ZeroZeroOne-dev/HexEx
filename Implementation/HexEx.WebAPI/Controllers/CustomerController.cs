using System;
using System.Threading.Tasks;
using HexEx.Application.IO.Commands;
using HexEx.Application.IO.Queries;
using HexEx.Application.IO.Reponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HexEx.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<GetCustomerQueryResponse>> GetCustomer(Guid id)
        {
            var response = await this.mediator.Send(new GetCustomerQuery { Id = id }, HttpContext.RequestAborted);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreateCustomerCommandResponse>> CreateCustomer(CreateCustomerCommand createCommand)
        {
            var response = await this.mediator.Send(createCommand, HttpContext.RequestAborted);

            return Ok(response);
        }

        [HttpPatch("{id:Guid}/postalcode/{postalCode}")]
        public async Task<ActionResult<GetCustomerQueryResponse>> SetPostalCode([FromRoute] Guid id, [FromRoute] string postalCode)
        {
            var response = await this.mediator.Send(new SetPostalCodeCommand { Id = id, PostalCode = postalCode }, HttpContext.RequestAborted);

            return Ok(response);
        }
    }
}