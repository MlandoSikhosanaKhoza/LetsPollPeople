using Blazored.LocalStorage;
using LetsPollPeople.UI;
using LetsPollPeople.UI.Auth;
using LetsPollPeople.UI.Services;
using LetsPollPeople.UI.Swagger;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using System.Text.Json;
using System.Text.Json.Serialization;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider,BlazorAuthenticationStateProvider>();
builder.Services.AddBlazoredLocalStorageAsSingleton();

builder.Services.AddScoped<HttpClientService>();
builder.Services.AddScoped<PollApiClient>();

await builder.Build().RunAsync();
