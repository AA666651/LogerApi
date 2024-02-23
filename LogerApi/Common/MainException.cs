using System;

namespace LogerApi.Common
{
    public class MainException :  Exception
    {
        public MainException()
        {
        }

        public MainException(string message)
            : base(message)
        {
        }

        public MainException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}