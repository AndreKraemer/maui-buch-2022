namespace ElVegetarianoFurio.Menu;

[QueryProperty(nameof(CategoryId), nameof(CategoryId))]
public partial class CategoryPage : ContentPage
{
    private readonly CategoryViewModel _viewModel;

    public CategoryPage(CategoryViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    public int CategoryId
    {
        get;
        set;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        _viewModel.CategoryId = CategoryId;
        // Hack. CategoryId ist 0, wenn wir
        // über das Menü der Shell zur Seite navigieren
        if(CategoryId == 0)
        {
            _viewModel.CategoryId = GetCategoryIdFromRoute();
        }
        await _viewModel.Initialize();
        base.OnNavigatedTo(args);
    }


    private int GetCategoryIdFromRoute()
    {
        // Hack: Die Shell kann derzeit deklarativ noch keine
        // Routenparameter bei der Navigation an eine Seite
        // weitergeben. Deshalb ermitteln wir hier die Route
        // der aktuellen Seite und geben hart codiert die ID
        // zurück. Die Lösung ist nich schön und sollte 
        // umgestellt werden, sobald die Shell bei der 
        // deklarativen Navigation Argumente übergeben kann
        var route = Shell.Current.CurrentState.Location
            .OriginalString.Split("/").LastOrDefault();
        return route switch
        {
            "ensaladas" => 1,
            "sopas" => 2,
            "tapas" => 3,
            "principales" => 4,
            "postres" => 5,
            "bebidas" => 6,
            _ => 0,
        };
    }
}
