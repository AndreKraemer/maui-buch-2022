using CodeSharingDemo.Services;
using CodeSharingDemo.iOS;

namespace CodeSharingDemo
{
    public static class ServiceCollectionRegistrationExtension
    {
        public static void RegisterPlatformServices(this IServiceCollection services)
        {
            services.AddTransient<IDeviceInformation, IosDeviceInformation>();
        }
    }
}
