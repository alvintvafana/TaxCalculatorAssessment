using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Web.Models
{
    public class CalculatedTaxViewModel
    {
        public Guid Id { get; set; }
        public string PostalCode { get; set; }
        public double AnnualIncome { get; set; }
        public double TaxAmount { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
