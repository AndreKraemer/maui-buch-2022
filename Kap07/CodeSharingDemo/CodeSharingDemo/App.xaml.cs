namespace CodeSharingDemo;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    public static IServiceProvider Services
    {
        get
        { 
#if __ANDROID__
            return MauiApplication.Current.Services;
#elif __IOS__
            return AppDelegate.Current.Services;
#elif WINDOWS
            return MauiWinUIApplication.Current.Services;
#else
            throw new PlatformNotSupportedException();
#endif
        }
    }
}
