using BlazorApp1;
using BlazorApp1.Services;
using BlazorApp1.Shared.ReqRes;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Polly;
using static System.Net.WebRequestMethods;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient("reqres", client =>
    client.BaseAddress = new Uri("https://reqres.in/api/"))
    .AddTransientHttpErrorPolicy(b =>
      b.WaitAndRetryAsync(new[]
      {
          TimeSpan.FromSeconds(1),
          TimeSpan.FromSeconds(5),
          TimeSpan.FromSeconds(10)
      }));
builder.Services.AddScoped<IReqResData, ReqResService>();


await builder.Build().RunAsync();
