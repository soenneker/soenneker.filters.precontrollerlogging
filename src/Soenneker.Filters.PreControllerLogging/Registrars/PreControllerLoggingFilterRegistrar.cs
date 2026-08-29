using Microsoft.AspNetCore.Mvc.Filters;

namespace Soenneker.Filters.PreControllerLogging.Registrars;

/// <summary>
/// Marks when a controller is hit and logs invalid model state errors.
/// </summary>
public static class PreControllerLoggingFilterRegistrar
{
    /// <summary>
    /// Adds a new <see cref="PreControllerLoggingFilterAttribute"/> to the filter collection<para/>
    /// </summary>
    /// <param name="filterCollection">filter Collection to inspect or update.</param>
    /// <returns>The resulting filter Collection.</returns>
    public static FilterCollection AddPreControllerLoggingFilter(this FilterCollection filterCollection)
    {
        filterCollection.Add(new PreControllerLoggingFilterAttribute());

        return filterCollection;
    }
}
