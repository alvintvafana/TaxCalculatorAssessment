using Microsoft.Extensions.Options;
using Assessment.TaxCalculator.Domain.Taxation.Dtos;
using Assessment.TaxCalculator.Domain.Taxation.OptionSets;
using System;
using System.Linq;

namespace Assessment.TaxCalculator.Domain.Taxation.Calculators
{
    public sealed class ProgressiveCalculator : ITax
    {
        private Progressive progressive;
        public ProgressiveCalculator(IOptions<TaxOptionSet> options)
        {
            progressive = options.Value.Progressive;
        }

        public double Calculate(double amount)
        {
            double taxTotal = 0;
            double amountUpperLimit = 0;
            foreach (var item in progressive.ProgressTax.OrderBy(a=>a.Rate))
            {

                if (item.ToAmount.Equals("-"))
                    amountUpperLimit = double.MaxValue;
                else
                    amountUpperLimit = double.Parse(item.ToAmount);

                if (amount > item.FromAmount)
                {
                    var taxableAtThisRate = Math.Min(amountUpperLimit - item.FromAmount, amount - item.FromAmount);
                    var toTax = taxableAtThisRate * item.Rate;
                    taxTotal += toTax;
                }
            }
            return taxTotal;
        }
    }
}
