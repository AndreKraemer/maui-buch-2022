using CodeSharingDemo.Services;
namespace CodeSharingDemo.Droid;
public class AndroidDeviceInformation : IDeviceInformation
{
    public  string GetName()
    {
        return Android.OS.Build.Device;
    }
}
