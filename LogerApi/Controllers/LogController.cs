using LogerApi.CommandBase;
using LogerApi.Common;
using LogerApi.Logic;
using LogerApi.Logic.Command;
using LogerApi.Logic.Query;
using LogerApi.QueryBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace LogerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly IQueriesProducer _queriesBus;
        private readonly ICommandsProducer _commandBus;


        public LogController(QueriesProducer queriesBus, ICommandsProducer commandBus)
        {
            _queriesBus = queriesBus;
            _commandBus = commandBus;
        }
        [HttpGet("GetListLogs")]
        public ListLogsResult GetListLogs()
        {
            var query = new GetListLogsQuery();
            var result = _queriesBus.Send<GetListLogsQuery,ListLogsResult>(query);
            return result;
        }
        [HttpPost("AddLog")]
        public void AddLog(string name, int? typeId)
        {
            var addCommand = new AddLogCommand();
            addCommand.Name = name;
            addCommand.TypeId = typeId;
            _commandBus.Send(addCommand);
        }
    }
}