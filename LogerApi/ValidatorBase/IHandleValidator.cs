namespace LogerApi.ValidatorBase
{
    public interface IHandleValidator<in TValidatable> : IHandleValidator where TValidatable : IValidatable
    {
        void Validate(TValidatable validatable);
    }

    public interface IHandleValidator
    {
    }
}