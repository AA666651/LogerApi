using System.Collections.Generic;

namespace LogerDatabase.DatabaseModel
{
    public class LogType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Log> Logs { get; set; }
    }
}