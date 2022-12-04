using CodeSharingDemo.Services;
namespace CodeSharingDemo.iOS;
public class IosDeviceInformation: IDeviceInformation
{
    public string GetName()
    {
        return UIKit.UIDevice.CurrentDevice.Name;
    }
}
