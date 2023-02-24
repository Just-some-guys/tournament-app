using Microsoft.AspNetCore.Http;

namespace TournamentApp.Application.Common.Extensions;
public static class HttpContextExtensions
{
    public static string GetOriginAddress(this HttpContext httpContext)
    {
        if (httpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
            return httpContext.Request.Headers["X-Forwarded-For"];

        return httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
    }
}
