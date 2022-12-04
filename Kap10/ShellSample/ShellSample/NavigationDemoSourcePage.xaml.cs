namespace ShellSample;

public partial class NavigationDemoSourcePage : ContentPage
{
    public NavigationDemoSourcePage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var navigationParameters = new Dictionary<string, object>
        {
            {"FirstName", FirstNameEntry.Text },
            {"LastName", LastNameEntry.Text },
            {"Age", AgeEntry.Text },
        };
        await Shell.Current.GoToAsync($"{nameof(NavigationDemoTargetPage)}", navigationParameters);
        //await Shell.Current.GoToAsync($"{nameof(NavigationDemoTargetPage)}?FirstName={FirstNameEntry.Text}&LastName={LastNameEntry.Text}&Age={AgeEntry.Text}");
    }
}