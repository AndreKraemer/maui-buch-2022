using CodeSharingDemo.Views;


namespace CodeSharingDemo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

//#if __ANDROID__
//        DependencyService.Register<CodeSharingDemo.Droid.AndroidDeviceInformation>();
//        builder.Services.AddTransient<IDeviceInformation, CodeSharingDemo.Droid.AndroidDeviceInformation>()
//#elif __MACCATALYST__
//        DependencyService.Register<CodeSharingDemo.MacCatalyst.MacCatalystDeviceInformation>();
//        builder.Services.AddTransient<IDeviceInformation, CodeSharingDemo.MacCatalyst.MacCatalystDeviceInformation>();
//#elif __IOS__
//        DependencyService.Register<CodeSharingDemo.iOS.IosDeviceInformation>();
//        builder.Services.AddTransient<IDeviceInformation, CodeSharingDemo.iOS.IosDeviceInformation>();
//#elif WINDOWS
//        DependencyService.Register<CodeSharingDemo.WinUI.WindowsDeviceInformation>();
//        builder.Services.AddTransient<IDeviceInformation, CodeSharingDemo.WinUI.WindowsDeviceInformation>();
//#endif
        builder.Services.AddTransient<DependencyInjectionDemoPage>();
        builder.Services.RegisterPlatformServices();
        DependencyServiceRegistration.RegisterPlatformDependencies();
        return builder.Build();
    }
}
