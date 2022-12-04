namespace ElVegetarianoFurio.Menu;

[QueryProperty(nameof(DishId), nameof(DishId))]
public partial class DishPage : ContentPage
{
    private readonly DishViewModel _viewModel;

    public DishPage(DishViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    public int DishId
    {
        get;
        set;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        _viewModel.DishId = DishId;
        await _viewModel.Initialize();
        base.OnNavigatedTo(args);
    }

}