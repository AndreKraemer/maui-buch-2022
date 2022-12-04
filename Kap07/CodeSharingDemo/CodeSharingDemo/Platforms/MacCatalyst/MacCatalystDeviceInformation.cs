using CodeSharingDemo.Services;
namespace CodeSharingDemo.MacCatalyst;

public class MacCatalystDeviceInformation : IDeviceInformation
{
    public string GetName()
    {
        return UIKit.UIDevice.CurrentDevice.Name;
    }
}
