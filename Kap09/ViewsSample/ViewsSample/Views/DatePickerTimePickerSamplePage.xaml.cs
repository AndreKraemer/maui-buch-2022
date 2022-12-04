using System.ComponentModel;

namespace ViewsSample.Views;

public partial class DatePickerTimePickerSamplePage : ContentPage
{
    public DatePickerTimePickerSamplePage()
    {
        InitializeComponent();
    }

    private void DatePicker_OnDateSelected(object sender, DateChangedEventArgs e)
    {
        ResultDateLabel.Text = e.NewDate.ToShortDateString();
    }

    private void TimePicker_Changed(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Time") // prüfen, ob die Uhrzeit verändert wurde
        {
            var timepicker = (TimePicker)sender;
            ResultTimeLabel.Text = timepicker.Time.ToString("g");
        }
    }
}