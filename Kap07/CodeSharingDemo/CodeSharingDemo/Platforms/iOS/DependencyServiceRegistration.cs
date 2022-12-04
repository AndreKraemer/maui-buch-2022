using CodeSharingDemo.iOS;

namespace CodeSharingDemo;

public static  class DependencyServiceRegistration
{
    public static void RegisterPlatformDependencies()
    {
        DependencyService.Register<IosDeviceInformation>();
    }
}
