using DeviceDemo.ViewModels;
using DeviceDemo.Views;


namespace DeviceDemo;

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

		builder.Services.AddTransient<AppInfoViewModel>();
        builder.Services.AddTransient<AppInfoPage>();
		builder.Services.AddSingleton<IAppInfo>(AppInfo.Current);

        builder.Services.AddTransient<MediaViewModel>();
        builder.Services.AddTransient<MediaPage>();
        builder.Services.AddSingleton<IMediaPicker>(MediaPicker.Default);
        return builder.Build();
	}
}
