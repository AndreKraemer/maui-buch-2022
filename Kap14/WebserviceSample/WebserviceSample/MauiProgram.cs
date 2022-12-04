using Microsoft.Extensions.DependencyInjection;
using MonkeyCache.FileStore;
using WebserviceSample.Models;
using WebserviceSample.Services;
using WebserviceSample.ViewModels;
using WebserviceSample.Views;

namespace WebserviceSample;

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

		builder.Services.AddSingleton<IDataStore<Speaker>, SpeakerDataStore>();
		builder.Services.AddTransient<NewSpeakerViewModel>();
        builder.Services.AddTransient<SpeakerDetailViewModel>();
        builder.Services.AddTransient<SpeakersViewModel>();
        builder.Services.AddTransient<NewSpeakerPage>();
        builder.Services.AddTransient<SpeakerDetailPage>();
        builder.Services.AddTransient<SpeakersPage>();

        Barrel.ApplicationId = "WebserviceSample Demo App";

        return builder.Build();
	}
}
