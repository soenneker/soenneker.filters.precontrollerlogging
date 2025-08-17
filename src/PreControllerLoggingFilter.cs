using Soenneker.Filters.PreControllerLogging.Abstract;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Soenneker.Constants.Apis;
using Soenneker.Extensions.HttpRequests;
using Soenneker.Extensions.ValueTask;
using Soenneker.Extensions.Dictionaries.IHeader;
using Soenneker.Extensions.Task;

namespace Soenneker.Filters.PreControllerLogging;

/// <inheritdoc cref="IPreControllerLoggingFilter"/>
public sealed class PreControllerLoggingFilterAttribute : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        context.HttpContext.Items[ApiConstants.ControllerHitFlag] = true;

        if (!context.ModelState.IsValid)
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<PreControllerLoggingFilterAttribute>>();

            string headers = context.HttpContext.Request.Headers.ToJsonString();
            string? body = await context.HttpContext.Request.ReadBody().NoSync();

            logger.LogWarning("Model validation failed for {Method} {Path}. Headers: {Headers} Body: {Body}", context.HttpContext.Request.Method,
                context.HttpContext.Request.Path + context.HttpContext.Request.QueryString, headers, body);
        }

        await base.OnActionExecutionAsync(context, next).NoSync();
    }
}