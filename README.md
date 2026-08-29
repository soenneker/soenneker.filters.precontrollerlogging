[![](https://img.shields.io/nuget/v/soenneker.filters.precontrollerlogging.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.filters.precontrollerlogging/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.filters.precontrollerlogging/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.filters.precontrollerlogging/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.filters.precontrollerlogging.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.filters.precontrollerlogging/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.filters.precontrollerlogging/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.filters.precontrollerlogging/actions/workflows/codeql.yml)

# Soenneker.Filters.PreControllerLogging

Marks when a controller is hit and logs invalid model state errors.

## Install

```bash
dotnet add package Soenneker.Filters.PreControllerLogging
```

## Quick start

```csharp
using Soenneker.Filters.PreControllerLogging.Registrars;

FilterCollection filterCollection = /* obtain from your application */;
var result = filterCollection.AddPreControllerLoggingFilter();
```

Adds a new `PreControllerLoggingFilterAttribute` to the filter collection.

## What you get

- `IPreControllerLoggingFilter` — Marks when a controller is hit and logs invalid model state errors.
- `PreControllerLoggingFilterRegistrar` — Marks when a controller is hit and logs invalid model state errors.
- `PreControllerLoggingFilterAttribute` — An MVC action filter that records that a controller was reached and logs the request headers and body when model validation fails.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `PreControllerLoggingFilterRegistrar.AddPreControllerLoggingFilter(filterCollection)` | Adds a new `PreControllerLoggingFilterAttribute` to the filter collection. | The resulting filter Collection. |
| `PreControllerLoggingFilterAttribute.OnActionExecutionAsync(context, next)` | Executes the on action execution async operation. | A task that represents the asynchronous operation. |
