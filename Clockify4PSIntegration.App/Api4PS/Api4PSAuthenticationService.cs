﻿using Clockify4PSIntegration.App.Api4PS.Request;
using Clockify4PSIntegration.App.Api4PS.Responses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Memory;

namespace Clockify4PSIntegration.App.Api4PS;

public interface ITokenAuthenticationService
{
    Task<TokenResponse> GetAccessTokenAsync(CancellationToken cancellationToken);
}

public record TokenResponse(string Token, DateTime Expires);

public class Api4PSAuthenticationService(
    IHttpClientFactory httpClientFactory,
    IConfiguration configuration) : ITokenAuthenticationService
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly IConfiguration _configuration = configuration;

    public async Task<TokenResponse> GetAccessTokenAsync(CancellationToken cancellationToken)
    {
        using var httpClient = _httpClientFactory.CreateClient("4PS");

        LoginRequest request = new(_configuration["4PS:Username"]!, _configuration["4PS:Password"]!, "HPT");

        var response = await httpClient.PostAsJsonAsync("_api/account/login", request, cancellationToken);

        response.EnsureSuccessStatusCode();

        var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>(cancellationToken) ??
            throw new InvalidDataException("Content could not be parsed");

        return new(loginResponse.Token, loginResponse.Expires);
    }
}

public class CachedAuthenticationService(
    [FromKeyedServices("basicAuthService")] ITokenAuthenticationService authenticationService,
    IMemoryCache cache) : ITokenAuthenticationService
{
    private readonly ITokenAuthenticationService _authenticationService = authenticationService;
    private readonly IMemoryCache _cache = cache;

    public async Task<TokenResponse> GetAccessTokenAsync(CancellationToken cancellationToken)
    {
        const string cacheKey = "AccessToken";
        if (_cache.TryGetValue(cacheKey, out TokenResponse? token))
            return token!;

        // Access token not found in cache, call the authentication service to obtain it
        token = await _authenticationService.GetAccessTokenAsync(cancellationToken);

        // Cache the access token till it expires
        var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(token.Expires.AddSeconds(-60L)); // reduce 1 min from actual expiration time to avoid unauthorized

        _cache.Set(cacheKey, token, cacheOptions);

        return token;
    }
}
