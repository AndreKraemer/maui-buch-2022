namespace CodeSharingDemo.Services;
public partial class DeviceService2
{
    public partial string GetDeviceName()
    {
        return Android.OS.Build.Device;
    }
}
