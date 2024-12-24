using EmploymentAgency.Client;
using EmploymentAgency.Client.Api;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7080") });




builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.AddSingleton<IEmploymentAgencyWrapper, EmploymentAgencyApiWrapper>(); //


await builder.Build().RunAsync();
