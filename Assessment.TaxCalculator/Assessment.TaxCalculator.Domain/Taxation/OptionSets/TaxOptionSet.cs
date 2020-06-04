using Assessment.TaxCalculator.Domain.Taxation.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.TaxCalculator.Domain.Taxation.OptionSets
{
    public class TaxOptionSet
    {
        public FlatRate FlatRate { get; set; }
        public FlatValue FlatValue { get; set; }
        public Progressive Progressive { get; set; }
    }
}
