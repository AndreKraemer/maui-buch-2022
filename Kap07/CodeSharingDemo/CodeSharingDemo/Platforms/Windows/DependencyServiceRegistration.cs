using CodeSharingDemo.WinUI;

namespace CodeSharingDemo;

public static  class DependencyServiceRegistration
{
    public static void RegisterPlatformDependencies()
    {
        DependencyService.Register<WindowsDeviceInformation>();
    }
}
