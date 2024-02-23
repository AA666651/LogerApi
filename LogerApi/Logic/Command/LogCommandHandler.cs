using System;
using LogerDatabase;
using System.Linq;
using LogerApi.CommandBase;
using LogerDatabase.DatabaseModel;

namespace LogerApi.Logic.Command
{
    public class LogCommandHandler : IHandleCommand<AddLogCommand>
    {
        private readonly LogerContext _context;

        public LogCommandHandler(LogerContext context)
        {
            _context = context;
        }
        public void Handle(AddLogCommand command)
        {
            var logType = _context.LogTypes.Where(x => x.Id == command.TypeId).First();
            _context.Logs.Add(new Log()
            {
                CreateDate = DateTime.Now,
                LogType = logType,
                Value = command.Name
            });
            _context.SaveChanges();
        }
    }
}
