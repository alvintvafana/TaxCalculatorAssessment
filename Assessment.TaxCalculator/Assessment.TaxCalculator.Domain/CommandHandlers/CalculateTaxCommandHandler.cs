using Assessment.TaxCalculator.Domain.Commands;
using Assessment.TaxCalculator.Domain.Entities;
using Assessment.TaxCalculator.Domain.Taxation;
using System;

namespace Assessment.TaxCalculator.Domain.CommandHandlers
{
    public sealed class CalculateTaxCommandHandler : ICommandHandler<CalculateTaxCommand>
    {
        private ITaxCalculatorFactory _taxCalculatorFactory;
        private IPayRepository _payRepository;
        public CalculateTaxCommandHandler(ITaxCalculatorFactory taxCalculatorFactory, IPayRepository payRepository)
        {
            _taxCalculatorFactory = taxCalculatorFactory;
            _payRepository = payRepository;
        }
        public void Handle(CalculateTaxCommand command)
        {
            var calculatedTax = new CalculatedTax
            {
                Id = command.Id,
                CreatedOn = DateTime.Now,
                AnnualIncome = command.AnnualIncome,
                PostalCode = command.PostalCode,
                TaxAmount = _taxCalculatorFactory.GetTax(command.PostalCode).Calculate(command.AnnualIncome)
            };
            _payRepository.Add(calculatedTax);
            _payRepository.Save();
        }
    }
}
