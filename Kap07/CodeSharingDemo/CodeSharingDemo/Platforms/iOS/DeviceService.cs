namespace CodeSharingDemo.Services;
public partial class DeviceService
{
    public partial string GetDeviceName()
    {
        return UIKit.UIDevice.CurrentDevice.Name;
    }
}
