using Autofac;
using System;
using System.Linq;
using LogerApi.CommandBase;
using LogerApi.ValidatorBase;

namespace LogerApi.CommandBase
{ 
    public class CommandsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(typeof(IHandleCommand).Assembly)
                .Where(x => x.IsAssignableTo<IHandleCommand>())
                .AsImplementedInterfaces();

            builder.Register<Func<Type, Type, IHandleCommand>>((c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return (queryType, returnType) =>
                {
                    var handlerType = typeof(IHandleCommand).MakeGenericType(queryType, returnType);
                    return (IHandleCommand)ctx.Resolve(handlerType);
                };
            }));
            builder.RegisterType<CommandsProducer>()
                .AsImplementedInterfaces();
        }
    }
}