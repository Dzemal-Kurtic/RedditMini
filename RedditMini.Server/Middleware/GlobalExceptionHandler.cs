using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RedditMini.Server.Exceptions;

namespace RedditMini.Server.Middleware;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problemDetails = exception switch
        {
            DuplicateCommunityNameException ex => new ProblemDetails
            {
                Status = StatusCodes.Status409Conflict,
                Title = "Community name already taken",
                Detail = ex.Message,
                Extensions = { ["name"] = ex.Name }
            },
            CommunityNotFoundException ex => new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Community not found",
                Detail = ex.Message,
                Extensions = { ["communityId"] = ex.CommunityId }
            },
            _ => null
        };

        if (problemDetails is null)
        {
            return false;
        }

        httpContext.Response.StatusCode = problemDetails.Status!.Value;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}
