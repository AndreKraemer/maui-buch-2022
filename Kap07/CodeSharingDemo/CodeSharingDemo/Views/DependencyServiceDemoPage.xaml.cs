using CodeSharingDemo.Services;

namespace CodeSharingDemo.Views;

public partial class DependencyServiceDemoPage : ContentPage
{
	public DependencyServiceDemoPage()
	{
		InitializeComponent();
        var deviceInfo = DependencyService.Get<IDeviceInformation>();
        DeviceInfoLabel.Text = deviceInfo.GetName();

    }
}