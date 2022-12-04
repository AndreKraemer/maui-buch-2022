using DeviceDemo.ViewModels;

namespace DeviceDemo.Views;

public partial class AppInfoPage : ContentPage
{
	public AppInfoPage(AppInfoViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}