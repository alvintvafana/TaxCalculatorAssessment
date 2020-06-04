using Assessment.TaxCalculator.Domain.Entities;
using Assessment.TaxCalculator.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.TaxCalculator.Domain.QueryHandler
{
   public sealed class GetCalculatedTaxQueryHandler : IQueryHandler<GetCalculatedTaxQuery, CalculatedTax>
    {
        IPayRepository _payRepository;
        public GetCalculatedTaxQueryHandler(IPayRepository payRepository)
        {
            _payRepository = payRepository;
        }
        public CalculatedTax Handle(GetCalculatedTaxQuery query)
        {
            return _payRepository.Get(query.ID);
        }
    }
}
