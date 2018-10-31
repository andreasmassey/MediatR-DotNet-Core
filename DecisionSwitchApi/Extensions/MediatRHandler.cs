using System.Reflection;
using Autofac;
using MediatR;

namespace Decision.Api.Extensions
{
    public static class MediatRHandler
    {
        public static void RegisterMediatRHandlers(this ContainerBuilder builder)
        {
            var mediatrOpenTypes = new[] {typeof(IRequestHandler<,>), typeof(INotificationHandler<>)};

            foreach (var mediatrOpenType in mediatrOpenTypes)
                builder.RegisterAssemblyTypes(typeof(Program).GetTypeInfo().Assembly).AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(Program).GetTypeInfo().Assembly).AsSelf().AsImplementedInterfaces();
        }
    }
}