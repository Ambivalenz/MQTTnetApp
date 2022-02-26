using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MQTTnetApp.Controls;

public sealed class RetainHandlingSelectorView : UserControl
{
    public RetainHandlingSelectorView()
    {
        InitializeComponent();
    }

    void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}