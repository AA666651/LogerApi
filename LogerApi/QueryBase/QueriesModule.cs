using Autofac;
using System;
using System.Linq;
using LogerApi.ValidatorBase;

namespace LogerApi.QueryBase
{
    public class QueriesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(typeof(IHandleQuery).Assembly)
                .Where(x => x.IsAssignableTo<IHandleQuery>())
                .AsImplementedInterfaces();

            builder.Register<Func<Type, Type, IHandleQuery>>((c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return (queryType, returnType) =>
                {
                    var handlerType = typeof(IHandleQuery<,>).MakeGenericType(queryType, returnType);
                    return (IHandleQuery)ctx.Resolve(handlerType);
                };
            }));
            builder.RegisterType<QueriesProducer>()
                .AsImplementedInterfaces();
        }
    }
}