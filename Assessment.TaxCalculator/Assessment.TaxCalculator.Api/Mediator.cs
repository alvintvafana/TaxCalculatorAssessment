using Microsoft.Extensions.DependencyInjection;
using Assessment.TaxCalculator.Domain.CommandHandlers;
using Assessment.TaxCalculator.Domain.Commands;
using Assessment.TaxCalculator.Domain.Queries;
using Assessment.TaxCalculator.Domain.QueryHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.TaxCalculator.Api
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _provider;

        public Mediator(IServiceProvider provider)
        {
            _provider = provider;
        }

        public void Dispatch(ICommand command)
        {
            using (var scope = _provider.CreateScope())
            {
                var commandType = command.GetType();
                var handlerType =
                    typeof(ICommandHandler<>).MakeGenericType(commandType);

                object handler = scope.ServiceProvider.GetRequiredService(handlerType);

                var handleMethod = handlerType.GetMethods()
                    .Single(s => s.Name == nameof(ICommandHandler<ICommand>.Handle));
                handleMethod.Invoke(handler, new[] { command });
            }
        }

        public T Dispatch<T>(IQuery<T> query)
        {
            using (var scope = _provider.CreateScope())
            {
                Type type = typeof(IQueryHandler<,>);
                Type[] typeArgs = { query.GetType(), typeof(T) };
                Type handlerType = type.MakeGenericType(typeArgs);

                object handler = scope.ServiceProvider.GetRequiredService(handlerType);

                var handleMethod = handlerType.GetMethods()
                    .Single(s => s.Name == nameof(IQueryHandler<IQuery<T>, T>.Handle));

                return (T)handleMethod.Invoke(handler, new[] { query });
            }
        }
    }
}
