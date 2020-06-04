using Assessment.TaxCalculator.Domain.Commands;

namespace Assessment.TaxCalculator.Domain.CommandHandlers
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
