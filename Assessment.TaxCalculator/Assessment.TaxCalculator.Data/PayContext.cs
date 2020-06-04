using Assessment.TaxCalculator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assessment.TaxCalculator.Data
{
    public class PayContext : DbContext
    {
        public PayContext(DbContextOptions<PayContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CalculatedTax> CalculatedTaxs { get; set; }
    }
}
