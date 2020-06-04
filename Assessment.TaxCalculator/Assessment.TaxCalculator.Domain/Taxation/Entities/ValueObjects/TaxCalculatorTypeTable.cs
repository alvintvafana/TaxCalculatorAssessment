using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.TaxCalculator.Domain.Taxation.Entities.ValueObjects
{
   public sealed class TaxCalculatorTypeTable
    {
        public string PostalCode { get; set; }
        public string TaxCalculationType { get; set; }
    }
}
