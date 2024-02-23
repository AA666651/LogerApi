using LogerApi.QueryBase;

namespace LogerApi.Logic.Query
{
    public class GetListLogsQuery : IQuery
    {
        public int? LogId { get; set; }
    }
}