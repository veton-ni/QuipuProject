

namespace Application.Exceptions
{
    [Serializable]
    public class BadRequestException : BaseException
    {

        public override int StatusCode { get; init; } = 400;
        public BadRequestException() { }

        public BadRequestException(string message)
            : base(message) { }

        public BadRequestException(string message, Exception inner)
            : base(message, inner) { }

    }
}
