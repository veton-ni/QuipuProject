

namespace Application.Exceptions
{
    public class BaseException : Exception
    {
        public virtual int StatusCode { get; init; } = 400;
        public BaseException() { }

        public BaseException(string message)
            : base(message) { }

        public BaseException(string message, Exception inner)
            : base(message, inner) { }


    }
}
