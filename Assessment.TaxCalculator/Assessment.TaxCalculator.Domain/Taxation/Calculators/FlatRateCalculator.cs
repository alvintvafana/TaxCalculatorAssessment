using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Assessment.TaxCalculator.Domain.Taxation.Dtos;
using Assessment.TaxCalculator.Domain.Taxation.Entities;
using Assessment.TaxCalculator.Domain.Taxation.OptionSets;

namespace Assessment.TaxCalculator.Domain.Taxation.Calculators
{
    public sealed class FlatRateCalculator : ITax
    {
        private FlatRate flatRate;
        public FlatRateCalculator(IOptions<TaxOptionSet> options)
        {
            flatRate = options.Value.FlatRate;
        }
        public double Calculate(double amount)
        {
            return amount * flatRate.Percentage;
        }
    }
}
