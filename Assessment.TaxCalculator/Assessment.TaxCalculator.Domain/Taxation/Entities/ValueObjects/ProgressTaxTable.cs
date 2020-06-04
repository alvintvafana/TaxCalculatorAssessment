using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.TaxCalculator.Domain.Taxation.Entities.ValueObjects
{
    public sealed class ProgressTaxTable
    {
        public double Rate { get; set; }
        public double FromAmount { get; set; }
        public string ToAmount { get; set; }
    }
}
