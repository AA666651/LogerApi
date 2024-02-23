using LogerDatabase;
using System.Linq;
using LogerApi.Common;
using LogerApi.ValidatorBase;

namespace LogerApi.Logic.Command
{
    public class AddCommandValidator : IHandleValidator<AddLogCommand>
    {
        private readonly LogerContext _context;

        public AddCommandValidator(LogerContext context)
        {
            _context = context;
        }
        public void Validate(AddLogCommand validation)
        {
            if (validation.TypeId == null)
            {
                throw new MainException("Nie podanno Typu wyjątku");
            }
            var exist = _context.LogTypes.Any(x => x.Id == validation.TypeId);
            if (!exist)
            {
                throw new MainException("Nie istnieje taki typ wyjatku");
            }
        }
    }
}