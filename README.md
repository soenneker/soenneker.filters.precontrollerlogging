[![](https://img.shields.io/nuget/v/soenneker.filters.precontrollerlogging.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.filters.precontrollerlogging/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.filters.precontrollerlogging/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.filters.precontrollerlogging/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.filters.precontrollerlogging.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.filters.precontrollerlogging/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.filters.precontrollerlogging/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.filters.precontrollerlogging/actions/workflows/codeql.yml)

# Soenneker.Filters.PreControllerLogging

An MVC action filter that marks requests reaching controller execution and records validation failures without logging request credentials or bodies.

## Installation

```bash
dotnet add package Soenneker.Filters.PreControllerLogging
```

## Register globally

```csharp
using Soenneker.Filters.PreControllerLogging.Registrars;

services.AddControllers(options =>
{
    options.Filters.AddPreControllerLoggingFilter();
});
```

The registrar adds one `PreControllerLoggingFilterAttribute` to MVC's filter collection and returns that collection for chaining.

## Behavior

Before the controller action runs, the filter sets:

```csharp
httpContext.Items[ApiConstants.ControllerHitFlag] = true;
```

When model state is invalid, it writes a warning containing the HTTP method, request path, and names of fields with validation errors. It deliberately omits the query string, headers, attempted values, validation exception details, and body because those commonly contain tokens, cookies, personal data, and passwords.

The filter then continues the normal MVC action-filter pipeline. It does not create a validation response, change status codes, or replace ASP.NET Core's `[ApiController]` model-state behavior.

## Logging considerations

Field names and paths can still be application-sensitive. Apply normal log access controls and retention policies. If a reverse proxy accepts arbitrary paths, normalize or constrain path logging at the application boundary as appropriate.
