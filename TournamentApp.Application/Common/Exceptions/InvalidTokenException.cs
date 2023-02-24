using System.Globalization;

namespace TournamentApp.Application.Common.Exceptions;
public class InvalidTokenException : Exception
{
    public InvalidTokenException() : base("Verification failed") { }

    public InvalidTokenException(string message) : base(message) { }

    public InvalidTokenException(string message, params object[] args)
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}
