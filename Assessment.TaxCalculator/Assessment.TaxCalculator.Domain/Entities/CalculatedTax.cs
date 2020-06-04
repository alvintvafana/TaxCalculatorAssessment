using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.TaxCalculator.Domain.Entities
{
   public class CalculatedTax
    {
        public Guid Id { get; set; }
        public string PostalCode { get; set; }
        public double AnnualIncome { get; set; }
        public double TaxAmount { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
