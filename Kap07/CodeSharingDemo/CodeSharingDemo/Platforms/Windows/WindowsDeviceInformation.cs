using CodeSharingDemo.Services;
using CodeSharingDemo.WinUI;

[assembly: Dependency(typeof(WindowsDeviceInformation))]

namespace CodeSharingDemo.WinUI;
public class WindowsDeviceInformation : IDeviceInformation
{
    public string GetName()
    {
        var deviceInformation = new Windows.Security
            .ExchangeActiveSyncProvisioning.EasClientDeviceInformation();
        return deviceInformation.FriendlyName;
    }
}