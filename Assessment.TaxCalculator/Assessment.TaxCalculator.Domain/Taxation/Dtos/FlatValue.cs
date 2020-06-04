using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.TaxCalculator.Domain.Taxation.Dtos
{
    public sealed class FlatValue
    {
       public LowestBracket LowestBracket { get; set; }
       public double FixedAmount { get; set; }
        
    }
}
