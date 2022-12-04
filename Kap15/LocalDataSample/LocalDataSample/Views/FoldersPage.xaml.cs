using LocalDataSample.ViewModels;

namespace LocalDataSample.Views;

public partial class FoldersPage : ContentPage
{
    private readonly FoldersViewModel _viewModel;

    public FoldersPage(FoldersViewModel viewModel)
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