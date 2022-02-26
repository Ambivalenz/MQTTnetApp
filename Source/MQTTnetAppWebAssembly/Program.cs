using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MQTTnetAppWebAssembly;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var hostBuilder = WebAssemblyHostBuilder.CreateDefault(args);
        hostBuilder.RootComponents.Add<App>("#app");
        hostBuilder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(hostBuilder.HostEnvironment.BaseAddress) });

        var host = hostBuilder.Build();
        await host.RunAsync();
    }
}