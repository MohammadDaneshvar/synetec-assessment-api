using System;

namespace Framework.Application
{
    public class ExceptionResult : Exception
    {
        public string Message { get; set; }
        public ExceptionResult(ExceptionResult exception)
        {
            Message = exception.Message;
        }
        public ExceptionResult(string message)
        {
            Message = message;
        }
    }
}
