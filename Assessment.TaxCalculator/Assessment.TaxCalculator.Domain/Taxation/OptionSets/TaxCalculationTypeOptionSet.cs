using Assessment.TaxCalculator.Domain.Taxation.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.TaxCalculator.Domain.Taxation.OptionSets
{
   public sealed class TaxCalculationTypeOptionSet
    {
        public List<TaxCalculatorTypeTable> TaxCalculatorTypes { get; set; }

        public TaxCalculationTypeOptionSet()
        {
            TaxCalculatorTypes = new List<TaxCalculatorTypeTable>();
        }
    }
}
