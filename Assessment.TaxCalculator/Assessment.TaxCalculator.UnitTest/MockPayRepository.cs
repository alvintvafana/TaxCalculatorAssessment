using Assessment.TaxCalculator.Domain;
using Assessment.TaxCalculator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pay.UnitTest
{
    public class MockPayRepository : IPayRepository
    {
        public  List<CalculatedTax> table= new List<CalculatedTax>();
        public void Add(CalculatedTax calculatedTax)
        {
           table.Add(calculatedTax);
        }

        public CalculatedTax Get(Guid id)
        {
            return table.FirstOrDefault(a => a.Id == a.Id);
        }

        public List<CalculatedTax> GetAll()
        {
            return table.OrderByDescending(a => a.CreatedOn).ToList();
        }

        public void Save()
        {
            //saving
        }
    }
}
