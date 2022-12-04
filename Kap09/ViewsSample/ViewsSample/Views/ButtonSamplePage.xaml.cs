namespace ViewsSample.Views;

public partial class ButtonSamplePage : ContentPage
{
    public ButtonSamplePage()
    {
        InitializeComponent();
    }

    private void Button_OnClicked(object sender, EventArgs e)
    {           
        (sender as Button).Text = "geklickt";
    }
}