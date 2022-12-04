using ViewsSample.ViewModels;

namespace ViewsSample.Views;

public partial class MvvmSamplePage : ContentPage
{
    public MvvmSamplePage()
    {
        InitializeComponent();
        BindingContext = new MvvmSampleViewModel();
    }
}