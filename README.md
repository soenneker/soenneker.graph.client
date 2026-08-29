[![](https://img.shields.io/nuget/v/soenneker.graph.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.graph.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.graph.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.graph.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.graph.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.graph.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.graph.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.graph.client/actions/workflows/codeql.yml)

# Soenneker.Graph.Client

An async thread-safe singleton for the Microsoft Graph client.

## Install

```bash
dotnet add package Soenneker.Graph.Client
```

## Quick start

```csharp
using Soenneker.Graph.Client.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddGraphClientUtilAsSingleton();
```

Adds `IGraphClientUtil` as a singleton service.

## What you get

- `IGraphClientUtil` — An async thread-safe singleton for the Microsoft Graph client.
- `GraphClientUtilRegistrar` — An async thread-safe singleton for the Microsoft Graph client.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `GraphClientUtilRegistrar.AddGraphClientUtilAsSingleton(services)` | Adds `IGraphClientUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `GraphClientUtilRegistrar.AddGraphClientUtilAsScoped(services)` | Adds `IGraphClientUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
