using Assessment.TaxCalculator.Domain;
using Assessment.TaxCalculator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment.TaxCalculator.Data
{
    public class PayRepository: IPayRepository
    {
        private PayContext _payContext;
        public PayRepository(PayContext payContext)
        {
            _payContext = payContext;
        }

        public void Add(CalculatedTax calculatedTax)
        {
            _payContext.Add(calculatedTax);
        }

        public CalculatedTax Get(Guid id)
        {
           return _payContext.CalculatedTaxs.FirstOrDefault(a => a.Id == id);
        }

        public List<CalculatedTax> GetAll()
        {
            return _payContext.CalculatedTaxs.OrderByDescending(a => a.CreatedOn).ToList();
        }

        public void Save()
        {
            _payContext.SaveChanges();
        }
    }
}
