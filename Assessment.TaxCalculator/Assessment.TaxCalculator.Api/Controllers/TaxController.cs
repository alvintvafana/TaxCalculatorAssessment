using Microsoft.AspNetCore.Mvc;
using Assessment.TaxCalculator.Api.Dto;
using Assessment.TaxCalculator.Domain.Commands;
using Assessment.TaxCalculator.Domain.Entities;
using Assessment.TaxCalculator.Domain.Queries;
using System;
using System.Collections.Generic;

namespace Assessment.TaxCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaxController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllCalculatedTaxQuery")]
        public ActionResult<IEnumerable<CalculatedTax>> Get()
        {
            var query= new GetAllCalculatedTaxQuery();
            var result = _mediator.Dispatch(query);
            return Ok(result);
        }

        [HttpGet("GetCalculatedTaxQuery")]
        public ActionResult<CalculatedTax> Get(Guid id)
        {
            var query = new GetCalculatedTaxQuery
            {
                ID=id
            };
            var result = _mediator.Dispatch(query);
            return Ok(result);
        }

        [HttpPost("CalculateTaxCommand")]
        public ActionResult CalculateTaxCommand([FromBody] CalculateTaxDto value)
        {
            var command = new CalculateTaxCommand
            {
                AnnualIncome = value.AnnualIncome,
                PostalCode = value.PostalCode
            };
           _mediator.Dispatch(command);
           return Ok(command.Id);
        }
    }
}
