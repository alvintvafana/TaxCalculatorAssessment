using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.TaxCalculator.Api.Dto
{
    public class CalculateTaxDto
    {
        public string PostalCode { get; set; }
        public double AnnualIncome { get; set; }
    }
}
