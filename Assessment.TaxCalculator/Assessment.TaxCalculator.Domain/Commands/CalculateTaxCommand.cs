using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.TaxCalculator.Domain.Commands
{
    public sealed class CalculateTaxCommand:ICommand
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string PostalCode { get; set; }
        public double AnnualIncome { get; set; }
    }
}
