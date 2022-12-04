namespace StylesSample.Views;
public partial class DarkModeLightModeSamplePage : ContentPage
{
    public DarkModeLightModeSamplePage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        DisplayCurrentTheme();
        Application.Current.RequestedThemeChanged += Application_ThemeChanged;
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        Application.Current.RequestedThemeChanged -= Application_ThemeChanged;
    }

    private void Application_ThemeChanged(object sender, AppThemeChangedEventArgs e)
    {
        DisplayCurrentTheme();
    }

    private void DisplayCurrentTheme()
    {
        switch (Application.Current.RequestedTheme)
        {
            case AppTheme.Unspecified:
                CurrentThemeLabel.Text = "Das aktuelle Theme ist nicht spezifiziert";
                break;
            case AppTheme.Dark:
                CurrentThemeLabel.Text = "Das aktuelle Theme ist dunkel";
                break;
            case AppTheme.Light:
                CurrentThemeLabel.Text = "Das aktuelle Theme ist hell";
                break;
        }
    }
}