using Soenneker.Filters.PreControllerLogging.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Soenneker.Constants.Apis;

namespace Soenneker.Filters.PreControllerLogging;

/// <summary>
/// An MVC action filter that records that a controller was reached and logs the request headers and body when model validation fails.
/// </summary>
/// <inheritdoc cref="IPreControllerLoggingFilter" />
public sealed class PreControllerLoggingFilterAttribute : ActionFilterAttribute, IPreControllerLoggingFilter
{
    /// <summary>
    /// Executes the on action execution async operation.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="next">The next.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        context.HttpContext.Items[ApiConstants.ControllerHitFlag] = true;

        if (!context.ModelState.IsValid)
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<PreControllerLoggingFilterAttribute>>();

            var invalidFields = new List<string>();
            foreach (KeyValuePair<string, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry> entry in context.ModelState)
            {
                if (entry.Value is { Errors.Count: > 0 })
                    invalidFields.Add(entry.Key);
            }

            logger.LogWarning("Model validation failed for {Method} {Path}. Invalid fields: {InvalidFields}", context.HttpContext.Request.Method,
                context.HttpContext.Request.Path, invalidFields);
        }

        await base.OnActionExecutionAsync(context, next).ConfigureAwait(false);
    }
}
