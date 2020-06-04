using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.TaxCalculator.Domain.Taxation
{
    public interface ITaxCalculatorFactory
    {
        ITax GetTax(string postalCode);
    }
}
