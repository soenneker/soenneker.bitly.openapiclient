[![](https://img.shields.io/nuget/v/soenneker.bitly.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.bitly.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.bitly.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.bitly.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.bitly.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.bitly.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.bitly.openapiclient/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.bitly.openapiclient/actions/workflows/codeql.yml)

# Soenneker.Bitly.OpenApiClient

A Kiota-generated .NET client containing request builders and models for Bitly's v4 API.

## Installation

```bash
dotnet add package Soenneker.Bitly.OpenApiClient
```

## Creating the client

```csharp
using System.Net.Http.Headers;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Bitly.OpenApiClient;

httpClient.BaseAddress = new Uri("https://api-ssl.bitly.com/v4/");
httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", accessToken);

var adapter = new HttpClientRequestAdapter(
    new AnonymousAuthenticationProvider(),
    httpClient: httpClient);

var client = new BitlyOpenApiClient(adapter);
```

For dependency-injection setup and cached client creation, use [`Soenneker.Bitly.OpenApiClientUtil`](https://www.nuget.org/packages/Soenneker.Bitly.OpenApiClientUtil).

## Usage

Retrieve the user associated with the access token:

```csharp
using Soenneker.Bitly.OpenApiClient.Models;

User? user = await client.User.GetAsync(cancellationToken: cancellationToken);
```

Create a short link:

```csharp
var request = new Shorten
{
    LongUrl = "https://example.com/articles/pragmatic-readmes"
};

ShortenBitlinkBody? result = await client.Shorten.PostAsync(
    request,
    cancellationToken: cancellationToken);
```

## Important behavior

- Request builders cover Bitlinks, short links, groups, organizations, campaigns, channels, QR codes, webhooks, and the authenticated user.
- Request and response types are in `Soenneker.Bitly.OpenApiClient.Models`.
- Generated methods accept Kiota request configuration for headers, query parameters, and middleware options where supported.
- Kiota surfaces mapped non-success responses through generated error models and `ApiException` behavior.
- The source is generated. Configure authentication, retries, and logging in the adapter or HTTP pipeline instead of editing generated files.
