using BlazorAV.Client;
using BlazorAV.Client.Services.CompanyService;
using BlazorAV.Client.Services.DesignationService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7175/") });
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IDesignationService, DesignationService>();
await builder.Build().RunAsync();
