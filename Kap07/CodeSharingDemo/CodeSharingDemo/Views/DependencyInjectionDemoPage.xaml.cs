using CodeSharingDemo.Services;

namespace CodeSharingDemo.Views;

public partial class DependencyInjectionDemoPage : ContentPage
{
    public DependencyInjectionDemoPage(IDeviceInformation deviceInfo)
    {
        InitializeComponent();
        DeviceInfoLabel.Text = deviceInfo.GetName();
    }
}