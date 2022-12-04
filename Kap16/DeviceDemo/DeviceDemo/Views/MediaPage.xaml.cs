using DeviceDemo.ViewModels;

namespace DeviceDemo.Views;

public partial class MediaPage : ContentPage
{
	public MediaPage(MediaViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}