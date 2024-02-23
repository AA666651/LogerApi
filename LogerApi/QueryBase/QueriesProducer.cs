using System;
using LogerApi.ValidatorBase;
using LogerApi.QueryBase;

namespace LogerApi.QueryBase
{
    public class QueriesProducer : IQueriesProducer
    {
        private readonly Func<Type, Type, IHandleQuery> _handlersFactory;
        private readonly Func<Type, IHandleValidator> _validatorFactory;

        public QueriesProducer(Func<Type, Type, IHandleQuery> handlersFactory, Func<Type, IHandleValidator> validatorFactory)
        {
            _handlersFactory = handlersFactory;
            _validatorFactory = validatorFactory;
        }

        public TResult Send<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            CallValidatorForQuery(query);
            var handler = (IHandleQuery<TQuery, TResult>)_handlersFactory(query.GetType(), typeof(TResult));
            var result = handler.Handle(query);
            return result;
        }

        private void CallValidatorForQuery<TQuery>(TQuery query) where TQuery : IQuery
        {
            var validator = (IHandleValidator<TQuery>)_validatorFactory(typeof(TQuery));
            validator?.Validate(query);
        }
    }
}