using LocalDataSample.Models;
using LocalDataSample.Services;
using LocalDataSample.ViewModels;
using LocalDataSample.Views;

namespace LocalDataSample;

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
        //builder.Services.AddSingleton<IDataStore<Item>, FileDataStore>();
        builder.Services.AddSingleton<IDataStore<Item>, DbDataStore>();
        builder.Services.AddTransient<FoldersViewModel>();
        builder.Services.AddTransient<ItemDetailViewModel>();
        builder.Services.AddTransient<ItemsViewModel>();
        builder.Services.AddTransient<NewItemViewModel>();
        builder.Services.AddTransient<FoldersPage>();
        builder.Services.AddTransient<ItemDetailPage>();
        builder.Services.AddTransient<ItemsPage>();
        builder.Services.AddTransient<NewItemPage>();


        return builder.Build();
    }
}
