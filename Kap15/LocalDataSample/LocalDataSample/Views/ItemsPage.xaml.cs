
using LocalDataSample.ViewModels;

namespace LocalDataSample.Views;

public partial class ItemsPage : ContentPage
{
    readonly ItemsViewModel _viewModel;

    public ItemsPage(ItemsViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {      
        _viewModel.Initialize();
        base.OnNavigatedTo(args);
    }
}