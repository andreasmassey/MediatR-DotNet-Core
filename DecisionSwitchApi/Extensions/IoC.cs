using Autofac;
using Autofac.Extensions.DependencyInjection;
using Decision.Api.Features.Decisions.DecisionEngineHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace Decision.Api.Extensions
{
    public static class IoC
    {
        public static IContainer BuildAutofaContainer(this IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(IoC).Assembly).AsClosedTypesOf(typeof(IDecisionEngineHandler));
            builder.RegisterMediatRHandlers();
            builder.Populate(services);

            return builder.Build();
        }
    }
}