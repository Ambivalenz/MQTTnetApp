using Avalonia.ReactiveUI;
using Avalonia.Web.Blazor;

namespace MQTTnetAppWebAssembly;

public partial class App
{
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        
        WebAppBuilder.Configure<MQTTnetApp.App>()
            .UseReactiveUI()
            .SetupWithSingleViewLifetime();
    }
}