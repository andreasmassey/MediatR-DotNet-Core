using System;
using Autofac;
using Decision.Api.Features.Decisions.DecisionEngineHandlers;

namespace Decision.Api.Tests
{
    public abstract class TestClassBase : IDisposable
    {
        protected ILifetimeScope Container;

        protected TestClassBase()
        {
            this.Container = Startup.Container.BeginLifetimeScope(ConfigureContainer);
        }

        public void Dispose()
        {
            this.Container.Dispose();
        }

        protected virtual void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<LegacyDecisionEngineHandler>().As<IDecisionEngineHandler>();
            builder.RegisterType<TemenosDecisionEngineHandler>().As<IDecisionEngineHandler>();
        }
    }
}