using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.TaxCalculator.Domain.Taxation.Dtos
{
    public sealed class LowestBracket
    {
        public double Amount { get; set; }
        public double Percentage { get; set; }
    }
}
