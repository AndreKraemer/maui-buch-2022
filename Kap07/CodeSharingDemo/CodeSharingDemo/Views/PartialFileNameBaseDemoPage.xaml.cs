using CodeSharingDemo.Services;

namespace CodeSharingDemo.Views;

public partial class PartialFileNameBaseDemoPage : ContentPage
{
	public PartialFileNameBaseDemoPage()
	{
		InitializeComponent();
        var deviceService2 = new DeviceService2();
        DeviceInfoLabel.Text = deviceService2.GetDeviceName();
    }
}