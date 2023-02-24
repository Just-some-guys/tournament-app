using System.Globalization;

namespace TournamentApp.Application.Common.Exceptions;
public class InvalidCredentialsException : Exception
{
    public InvalidCredentialsException() : base("Email or password is incorrect") { }

    public InvalidCredentialsException(string message) : base(message) { }

    public InvalidCredentialsException(string message, params object[] args)
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}
