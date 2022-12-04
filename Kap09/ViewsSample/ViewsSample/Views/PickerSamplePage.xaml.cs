namespace ViewsSample.Views;
public partial class PickerSamplePage : ContentPage
{
    public PickerSamplePage()
    {
        InitializeComponent();
    }

    private void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var index = picker.SelectedIndex;

        if (index != -1)
        {
            ResultLabel.Text = picker.Items[index];
        }
    }
}