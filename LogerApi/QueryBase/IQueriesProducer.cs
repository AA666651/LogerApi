namespace LogerApi.QueryBase
{
    public interface IQueriesProducer
    {
        TResult Send<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }
}