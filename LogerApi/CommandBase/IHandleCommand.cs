namespace LogerApi.CommandBase
{
    public interface IHandleCommand<in TCommand> : IHandleCommand
       where TCommand : ICommand
    {
        void Handle(TCommand command);
    }

    public interface IHandleCommand
    {
    }
}
