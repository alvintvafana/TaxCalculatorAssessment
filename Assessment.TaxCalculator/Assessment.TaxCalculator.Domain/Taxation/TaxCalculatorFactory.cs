using Microsoft.Extensions.Options;
using Assessment.TaxCalculator.Domain.Taxation.Calculators;
using Assessment.TaxCalculator.Domain.Taxation.Entities;
using Assessment.TaxCalculator.Domain.Taxation.Entities.ValueObjects;
using Assessment.TaxCalculator.Domain.Taxation.OptionSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assessment.TaxCalculator.Domain.Taxation
{
   public sealed class TaxCalculatorFactory: ITaxCalculatorFactory
    {
       private Dictionary<string, ITax> taxCalculationType= new Dictionary<string, ITax>();
       private List<TaxCalculatorTypeTable> _taxCalculatorTypes;


        public TaxCalculatorFactory(IOptions<TaxOptionSet> options, IOptions<TaxCalculationTypeOptionSet> taxCalculationTypeOption)
        {
            taxCalculationType .Add("Progressive",new ProgressiveCalculator(options));
            taxCalculationType.Add("Flat Value", new FlatValueCalculator(options));
            taxCalculationType.Add("Flat Rate", new FlatRateCalculator(options));
            _taxCalculatorTypes = taxCalculationTypeOption.Value.TaxCalculatorTypes;
        }

        public ITax GetTax(string postalCode)
        {
            var taxCalculationTypeToUse = _taxCalculatorTypes.FirstOrDefault(a=>a.PostalCode==postalCode);
            if(taxCalculationTypeToUse==null)
                throw new ArgumentNullException("postalCode Code was not setup");
            var taxCalculator = taxCalculationType[taxCalculationTypeToUse.TaxCalculationType];
            return taxCalculator;
        }
    }
}