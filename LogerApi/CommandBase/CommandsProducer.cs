using System;
using LogerApi.ValidatorBase;

namespace LogerApi.CommandBase
{
    public class CommandsProducer : ICommandsProducer
    {
        private readonly Func<Type, IHandleCommand> _handlersFactory;
        private readonly Func<Type, IHandleValidator> _validatorFactory;

        public CommandsProducer(Func<Type, IHandleCommand> handlersFactory, Func<Type, IHandleValidator> validatorFactory)
        {
            _handlersFactory = handlersFactory;
            _validatorFactory = validatorFactory;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            CallValidatorForCommand(command);
            var handler = (IHandleCommand<TCommand>)_handlersFactory(typeof(TCommand));
            handler.Handle(command);
        }

        private void CallValidatorForCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            var validator = (IHandleValidator<TCommand>)_validatorFactory(typeof(TCommand));
            validator?.Validate(command);
        }
    }
}
