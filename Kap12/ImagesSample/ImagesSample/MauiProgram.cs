namespace ImagesSample;

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
                fonts.AddFont("IndieFlower-Regular.ttf", "IndieFlower");
                fonts.AddFont("Font Awesome 5 Free-Regular-400.otf", "FontAwesome");
                fonts.AddFont("DancingScript-VariableFont_wght.ttf", "DancingScript");
            });

		return builder.Build();
	}
}
