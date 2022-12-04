namespace CodeSharingDemo.Services;
public partial class DeviceService
{
    public partial string GetDeviceName()
    {
        return Android.OS.Build.Device;
    }
}
