using Assessment.TaxCalculator.Domain.Entities;
using Assessment.TaxCalculator.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.TaxCalculator.Domain.QueryHandler
{
   public sealed class GetAllCalculatedTaxQueryHandler: IQueryHandler<GetAllCalculatedTaxQuery, List<CalculatedTax>>
   {
       IPayRepository _payRepository;

       public GetAllCalculatedTaxQueryHandler(IPayRepository payRepository)
       {
           _payRepository = payRepository;
       }

        public List<CalculatedTax> Handle(GetAllCalculatedTaxQuery query)
        {
            return _payRepository.GetAll();
        }
    }
}
