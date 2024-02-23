using System.Linq;
using LogerApi.ValidatorBase;
using LogerApi.ViewModel;
using LogerDatabase;

namespace LogerApi.Logic.Query
{
    public class LogsQuery : IHandleQuery<GetListLogsQuery, ListLogsResult>
    {
        private readonly LogerContext _context;

        public LogsQuery(LogerContext context)
        {
            _context = context;
        }

        public ListLogsResult Handle(GetListLogsQuery command)
        {
            var losResult =
                from logs in _context.Logs
                join logType in _context.LogTypes on logs.LogType.Id equals logType.Id
                select new LogsVM
                {
                    Name = logs.Value, 
                    LogType = logType.Name,
                    Id = logs.Id
                }; 

            return new ListLogsResult()
            {
                Logs = losResult.ToList()
            };
        }                                                                                     
    }
}