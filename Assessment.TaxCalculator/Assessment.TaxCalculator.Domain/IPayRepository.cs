using Assessment.TaxCalculator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.TaxCalculator.Domain
{
    public interface IPayRepository
    {
        void Add(CalculatedTax calculatedTax);
        void Save();
        CalculatedTax Get(Guid id);
        List<CalculatedTax> GetAll();
    }
}
