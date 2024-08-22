using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using TechChallenge.Web;
using TechChallenge.Web.WebServices;
using TechChallenge.Web.WebServices.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddRadzenComponents();

builder.Services.AddScoped<IContactWebService, ContactWebService>();
builder.Services.AddScoped<IStateWebService, StateWebService>();

var defaultApiUrl = builder.Configuration.GetValue<string>("ApiUrl");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(defaultApiUrl) });

await builder.Build().RunAsync();
