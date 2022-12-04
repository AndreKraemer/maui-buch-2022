using ElVegetarianoFurio.Core;
using ElVegetarianoFurio.Data;
using ElVegetarianoFurio.Menu;
using ElVegetarianoFurio.Profile;

namespace ElVegetarianoFurio;

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

        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddSingleton<IProfileService, ProfileService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<IDataService, DummyDataService>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<CategoryViewModel>();
        builder.Services.AddTransient<CategoryPage>();
        builder.Services.AddTransient<DishViewModel>();
        builder.Services.AddTransient<DishPage>();
        return builder.Build();
	}
}
