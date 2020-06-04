using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.TaxCalculator.Domain.QueryHandler
{
    public interface IQueryHandler<TQuery, TResult>
    {
        TResult Handle(TQuery query);
    }
}
