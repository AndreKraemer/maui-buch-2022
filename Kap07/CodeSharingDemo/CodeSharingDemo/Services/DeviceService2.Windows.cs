namespace CodeSharingDemo.Services;
public partial class DeviceService2
{
    public partial string GetDeviceName()
    {
        var deviceInformation = new Windows.Security
            .ExchangeActiveSyncProvisioning.EasClientDeviceInformation();
        return deviceInformation.FriendlyName;
    }
}
