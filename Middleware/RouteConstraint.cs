namespace FoodMenuApi.Middlewares{
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class RouteConstraintMiddleware
{
    private readonly RequestDelegate _next;

    public RouteConstraintMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Check if the route constraint failed
        if (context.Items.TryGetValue("RouteConstraintErrorMessage", out var errorMessage))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync(errorMessage.ToString());
            return;
        }

        // Pass the request to the next middleware
        await _next(context);
    }
}

}