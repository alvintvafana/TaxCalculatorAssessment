using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Assessment.TaxCalculator.Data;
using Assessment.TaxCalculator.Domain;
using Assessment.TaxCalculator.Domain.CommandHandlers;
using Assessment.TaxCalculator.Domain.Commands;
using Assessment.TaxCalculator.Domain.Entities;
using Assessment.TaxCalculator.Domain.Queries;
using Assessment.TaxCalculator.Domain.QueryHandler;
using Assessment.TaxCalculator.Domain.Taxation;
using Assessment.TaxCalculator.Domain.Taxation.OptionSets;
using Swashbuckle.AspNetCore.Swagger;


namespace Assessment.TaxCalculator.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PayContext>
            (options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<TaxOptionSet>(Configuration.GetSection("TaxOptionSet"));

            services.Configure<TaxCalculationTypeOptionSet>(Configuration.GetSection("TaxCalculationTypeOptionSet"));

            services.AddScoped<IPayRepository, PayRepository>();
            services.AddScoped<ICommandHandler<CalculateTaxCommand>, CalculateTaxCommandHandler>();
            services.AddScoped<ICommandHandler<CalculateTaxCommand>, CalculateTaxCommandHandler>();
            services.AddScoped<IQueryHandler<GetCalculatedTaxQuery, CalculatedTax>, GetCalculatedTaxQueryHandler>();
            services.AddScoped<IQueryHandler<GetAllCalculatedTaxQuery, List<CalculatedTax>>, GetAllCalculatedTaxQueryHandler>();
            services.AddSingleton<ITaxCalculatorFactory, TaxCalculatorFactory>();
            services.AddSingleton<IMediator, Mediator>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }
    }
}
