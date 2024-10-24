using Clockify4PSIntegration.App.Api4PS;
using Clockify4PSIntegration.App.Clockify;
using Clockify4PSIntegration.App.Components;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKeyedScoped<ITokenAuthenticationService, Api4PSAuthenticationService>("basicAuthService");
builder.Services.AddScoped<ITokenAuthenticationService, CachedAuthenticationService>();
builder.Services.AddMemoryCache();

builder.Services.AddTransient<Api4PSAuthenticationHandler>();
builder.Services.AddHttpClient<Api4PSService>("4PS", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["4PS:BaseAddress"]!);
}).AddHttpMessageHandler<Api4PSAuthenticationHandler>();

builder.Services.AddTransient<ClockifyApiKeyAuthenticationHandler>();
builder.Services.AddHttpClient<ClockifyService>("clockify", client =>
    client.BaseAddress = new Uri(builder.Configuration["Clockify:BaseAddress"]!))
    .AddHttpMessageHandler<ClockifyApiKeyAuthenticationHandler>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
