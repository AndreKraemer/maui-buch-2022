using CodeSharingDemo.Droid;

namespace CodeSharingDemo;

public static  class DependencyServiceRegistration
{
    public static void RegisterPlatformDependencies()
    {
        DependencyService.Register<AndroidDeviceInformation>();
    }
}
