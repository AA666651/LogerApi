using LogerApi.QueryBase;

namespace LogerApi.ValidatorBase
{
    public interface IHandleQuery<in TQuery, out TResult> : IHandleQuery, IValidatable
        where TQuery : IQuery
    {
        TResult Handle(TQuery query);
    }

    public interface IHandleQuery
    {
    }
}