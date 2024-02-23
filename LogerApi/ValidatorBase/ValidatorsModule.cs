using System;
using Autofac;

namespace LogerApi.ValidatorBase
{
    public class ValidatorsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(typeof(IHandleValidator).Assembly)
                .Where(x => x.IsAssignableTo<IHandleValidator>())
                .AsImplementedInterfaces();


            builder.Register<Func<Type, IHandleValidator>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return t =>
                {
                    var handlerType = typeof(IHandleValidator<>).MakeGenericType(t);
                    return (IHandleValidator)ctx.ResolveOptional(handlerType);
                };
            });
        }
    }
}