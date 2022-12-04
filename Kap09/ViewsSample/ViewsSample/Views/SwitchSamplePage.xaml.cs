namespace ViewsSample.Views;

public partial class SwitchSamplePage : ContentPage
{
    public SwitchSamplePage()
    {
        InitializeComponent();
    }


    private async void Switch_OnToggled(object sender, ToggledEventArgs e)
    {
        try
        {
            if (e.Value)
            {
                await Flashlight.TurnOnAsync();
            }
            else
            {
                await Flashlight.TurnOffAsync();
            }
        }
        catch (FeatureNotSupportedException)
        {
            await DisplayAlert("Taschenlampe", $"Taschenlampe wird auf diesem Gerät nicht unterstützt. Wert: {e.Value}", "Ok");
        }
        catch (PermissionException)
        {
            await DisplayAlert("Taschenlampe", $"Berechtigung für Taschenlampe fehlt. Wert: {e.Value}", "Ok");
        }
    }
}