using LogerApi.CommandBase;

namespace LogerApi.Logic.Command
{
    public class AddLogCommand : ICommand
    {
        public string Name { get; set; }
        public int? TypeId { get; set; }
    }
}
