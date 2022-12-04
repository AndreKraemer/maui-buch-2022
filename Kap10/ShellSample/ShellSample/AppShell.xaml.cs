namespace ShellSample;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(NavigationDemoTargetPage), typeof(NavigationDemoTargetPage));
	}

	private async void MenuItem_Clicked(object sender, EventArgs e)
	{
        await DisplayAlert("Versionsinfo", "1.0.0", "Ok");
        FlyoutIsPresented = false; // Flyout wieder schließen
    }
}
