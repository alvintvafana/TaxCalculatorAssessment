using System;
using System.Collections.Generic;
using System.Text;
using Assessment.TaxCalculator.Domain.Entities;

namespace Assessment.TaxCalculator.Domain.Queries
{
    public sealed class GetCalculatedTaxQuery : IQuery<CalculatedTax>
    {
        public Guid ID { get; set; }
    }
}
