using System;
using LogerApi.Common;
using LogerApi.ValidatorBase;

namespace LogerApi.Logic.Query
{
    public class AddCommandValidator : IHandleValidator<GetListLogsQuery>
    {

        public void Validate(GetListLogsQuery validation)
        {
            if (validation.LogId == null)
            {
                throw new MainException("Puste pole logId");
            }
        }
    }
}