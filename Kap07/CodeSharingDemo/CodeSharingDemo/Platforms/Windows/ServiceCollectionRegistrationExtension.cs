using CodeSharingDemo.Services;
using CodeSharingDemo.WinUI;

namespace CodeSharingDemo
{
    public static class ServiceCollectionRegistrationExtension
    {
        public static void RegisterPlatformServices(this IServiceCollection services)
        {
            services.AddTransient<IDeviceInformation, WindowsDeviceInformation>();
        }
    }
}
