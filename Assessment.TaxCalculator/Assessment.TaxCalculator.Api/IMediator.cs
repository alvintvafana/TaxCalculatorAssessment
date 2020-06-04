using Assessment.TaxCalculator.Domain.Commands;
using Assessment.TaxCalculator.Domain.Queries;
using System.Threading.Tasks;

namespace Assessment.TaxCalculator.Api
{
    public interface IMediator
    {
        void Dispatch(ICommand command);
        T Dispatch<T>(IQuery<T> query);
    }
}
