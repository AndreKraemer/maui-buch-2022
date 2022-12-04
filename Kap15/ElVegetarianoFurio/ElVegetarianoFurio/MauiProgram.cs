using ElVegetarianoFurio.Core;
using ElVegetarianoFurio.Data;
using ElVegetarianoFurio.Menu;
using ElVegetarianoFurio.Profile;
using MonkeyCache.FileStore;

namespace ElVegetarianoFurio;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        Barrel.ApplicationId = "ElVegetarianoFurio";
        var builder = MauiApp.CreateBuilder();
	    builder
		    .UseMauiApp<App>()
		    .ConfigureFonts(fonts =>
		    {
			    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Font Awesome 5 Free-Solid-900.otf", "Fa-Solid");
                fonts.AddFont("ShadowsIntoLight-Regular.ttf", "Shadows");
                fonts.AddFont("Sofia-Regular.ttf", "Sofia");
            });

        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddSingleton<IProfileService, ProfileService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<IDataService, WebApiDataService>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<CategoryViewModel>();
        builder.Services.AddTransient<CategoryPage>();
        builder.Services.AddTransient<DishViewModel>();
        builder.Services.AddTransient<DishPage>();
        return builder.Build();
	}
}
