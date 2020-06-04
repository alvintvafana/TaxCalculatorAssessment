using Assessment.TaxCalculator.Domain.Taxation.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.TaxCalculator.Domain.Taxation.Dtos
{
    public sealed class Progressive
    {
        public Progressive()
        {
            ProgressTax= new List<ProgressTaxTable>();
        }
       public List<ProgressTaxTable> ProgressTax { get; set; }
    }
}
