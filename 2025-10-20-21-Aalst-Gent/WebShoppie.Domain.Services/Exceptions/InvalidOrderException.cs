namespace WebShoppie.Domain.Services.Exceptions
{
    public class InvalidOrderException : Exception
    {
        public InvalidOrderException() : base("Invalid Order. Please contact support.") { }
        public InvalidOrderException(string message) : base(message) { }

    }
}
