using System;
using System.Collections.Generic;
using Autofac;
using Decision.Api.Features.Decisions.DecisionEngineHandlers;
using Moq;

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
            builder.Register(x => new Mock<IEnumerable<IDecisionEngineHandler>>().Object);

        }
    }
}