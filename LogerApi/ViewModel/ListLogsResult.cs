using System.Collections.Generic;
using LogerApi.ViewModel;

namespace LogerApi.Logic
{
    public class ListLogsResult 
    {
        public IList<LogsVM> Logs { get; set; }
    }
}