using Assessment.TaxCalculator.Domain;
using Assessment.TaxCalculator.Domain.CommandHandlers;
using Assessment.TaxCalculator.Domain.Commands;
using Assessment.TaxCalculator.Domain.Taxation;
using Assessment.TaxCalculator.Domain.Taxation.Dtos;
using Assessment.TaxCalculator.Domain.Taxation.Entities.ValueObjects;
using Assessment.TaxCalculator.Domain.Taxation.OptionSets;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using Pay.UnitTest;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class TaxCalculationTest
    {
        private Mock<IOptions<TaxOptionSet>> iOptionsMock = new Mock<IOptions<TaxOptionSet>>();
        private Mock<IOptions<TaxCalculationTypeOptionSet>> taxCalculationTypeOptionMock = new Mock<IOptions<TaxCalculationTypeOptionSet>>();

        [SetUp]
        public void Setup()
        {
            var progressive = new Progressive();
            progressive.ProgressTax.Add(new ProgressTaxTable{Rate = 0.10,FromAmount = 0,ToAmount = "8350"});
            progressive.ProgressTax.Add(new ProgressTaxTable { Rate = 0.20, FromAmount = 8351, ToAmount = "33950"});
            iOptionsMock.SetupGet(a => a.Value).Returns(new TaxOptionSet()
            {
                FlatRate = new FlatRate { Percentage = 0.175},
                FlatValue = new FlatValue { FixedAmount = 10000,LowestBracket = new LowestBracket{Percentage = 0.05,Amount = 200000 } },
                Progressive = progressive
            });

            var taxCalculatorTypes = new List<TaxCalculatorTypeTable>();
            taxCalculatorTypes.Add(new TaxCalculatorTypeTable{PostalCode = "7441",TaxCalculationType = "Progressive" });
            taxCalculatorTypes.Add(new TaxCalculatorTypeTable { PostalCode = "A100", TaxCalculationType = "Flat Value" });
            taxCalculatorTypes.Add(new TaxCalculatorTypeTable { PostalCode = "7000", TaxCalculationType = "Flat Rate" });
            taxCalculationTypeOptionMock.SetupGet(a => a.Value).Returns(new TaxCalculationTypeOptionSet()
                {TaxCalculatorTypes = taxCalculatorTypes});

        }

        [TestCase("7441", 100, 10d)]
        [TestCase("A100", 100, 5d)]
        [TestCase("7000", 100, 17.5d)]
        [TestCase("A100", 210000, 10000d)]
        [TestCase("7441", 50000, 5954.8d)]
        public void ComputeTax(string postalCode, double annualIncome, double taxAmount)
        {
            //Given
            IPayRepository mockPayRepository = new MockPayRepository();
            var taxCalculatorFactory =
                new TaxCalculatorFactory(iOptionsMock.Object, taxCalculationTypeOptionMock.Object);

            var command = new CalculateTaxCommandHandler(taxCalculatorFactory, mockPayRepository);

            //When
           command.Handle(new CalculateTaxCommand
            {
                AnnualIncome = annualIncome,
                PostalCode = postalCode
            });

            //Then
            var row = ((MockPayRepository) mockPayRepository).table[0];

            Assert.NotNull(row);
            Assert.AreEqual(postalCode, row.PostalCode);
            Assert.AreEqual(annualIncome, row.AnnualIncome);
            Assert.AreEqual(taxAmount, row.TaxAmount);

        }
        [TestCase("7941", 100, 10d)]
        public void ComputeTax_Fail(string postalCode, double annualIncome, double taxAmount)
        {
            //Given
            MockPayRepository mockPayRepository = new MockPayRepository();
            var taxCalculatorFactory =
                new TaxCalculatorFactory(iOptionsMock.Object, taxCalculationTypeOptionMock.Object);

            var insertCalculatedTaxCommandHandler = new CalculateTaxCommandHandler(taxCalculatorFactory, mockPayRepository);

            Assert.Throws<ArgumentNullException>(()=>insertCalculatedTaxCommandHandler.Handle(new CalculateTaxCommand
            {
                AnnualIncome = annualIncome,
                PostalCode = postalCode
            }));
        }
    }
}