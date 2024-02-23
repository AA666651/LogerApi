namespace LogerApi.CommandBase
{
    public interface ICommandsProducer
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
