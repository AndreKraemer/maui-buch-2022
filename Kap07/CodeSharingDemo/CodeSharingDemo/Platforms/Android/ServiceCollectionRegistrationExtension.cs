using CodeSharingDemo.Services;
using CodeSharingDemo.Droid;

namespace CodeSharingDemo
{
    public static class ServiceCollectionRegistrationExtension
    {
        public static void RegisterPlatformServices(this IServiceCollection services)
        {
            services.AddTransient<IDeviceInformation, AndroidDeviceInformation>();
        }
    }
}
