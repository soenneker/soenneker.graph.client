[![](https://img.shields.io/nuget/v/soenneker.graph.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.graph.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.graph.client/build-and-test.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.graph.client/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.graph.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.graph.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.graph.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.graph.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.graph.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.graph.client/actions/workflows/codeql.yml)

# Soenneker.Graph.Client

A lazy, thread-safe `GraphServiceClient` provider using Microsoft Entra client-credential authentication.

## Install

```bash
dotnet add package Soenneker.Graph.Client
```

## Configuration

```json
{
  "Azure": {
    "AzureAd": {
      "TenantId": "<tenant ID>",
      "ClientId": "<application client ID>",
      "ClientSecret": "<client secret>"
    }
  }
}
```

These values are read when the provider is constructed. The app registration needs application permissions for the Graph operations your application performs, with tenant admin consent where required.

## Register

```csharp
using Soenneker.Graph.Client.Registrars;
using Microsoft.Extensions.DependencyInjection;

services.AddGraphClientUtilAsSingleton();
```

Singleton registration is the normal ownership boundary: scoped Graph utilities can be disposed while the authenticated client remains available to later scopes. `AddGraphClientUtilAsScoped()` is available when a separate client is deliberately required per scope.

## Usage

```csharp
using Microsoft.Graph;
using Microsoft.Graph.Models;

GraphServiceClient graph = await graphClientUtil.Get(cancellationToken);

UserCollectionResponse? page = await graph.Users.GetAsync(
    cancellationToken: cancellationToken);
```

Every `Get()` call on the same provider returns the same lazily created client. Authentication uses the application identity, not an interactive or delegated user login.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `Get(cancellationToken)` | Gets or creates the authenticated Graph client. | Cached for the provider lifetime. |
| `AddGraphClientUtilAsSingleton()` | Registers one client provider application-wide. | Intended dependency for scoped Graph utilities. |
| `AddGraphClientUtilAsScoped()` | Registers a separate provider per scope. | Scope disposal also disposes that scope's client. |

## Practical notes

- Cancellation can stop pending lazy initialization and should also be passed to individual Graph SDK requests.
- Let the DI container dispose registered providers. Dispose manually constructed providers yourself.
