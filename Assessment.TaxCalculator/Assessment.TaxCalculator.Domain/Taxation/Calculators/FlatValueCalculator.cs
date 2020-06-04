using Microsoft.Extensions.Options;
using Assessment.TaxCalculator.Domain.Taxation.Dtos;
using Assessment.TaxCalculator.Domain.Taxation.OptionSets;

namespace Assessment.TaxCalculator.Domain.Taxation.Calculators
{
    public sealed class FlatValueCalculator : ITax
    {
        private FlatValue flatValue;
        public FlatValueCalculator(IOptions<TaxOptionSet> options)
        {
            flatValue = options.Value.FlatValue;
        }

        public double Calculate(double amount)
        {
            if (amount <= flatValue.LowestBracket.Amount)
                return amount * flatValue.LowestBracket.Percentage;
            return flatValue.FixedAmount;
        }
    }
}
