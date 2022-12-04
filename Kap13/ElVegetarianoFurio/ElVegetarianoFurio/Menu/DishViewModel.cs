using ElVegetarianoFurio.Core;
using ElVegetarianoFurio.Data;

namespace ElVegetarianoFurio.Menu;

public class DishViewModel : BaseViewModel
{
    private readonly IDataService _dataService;
    private Dish _dish;
    private int _dishId;

    public Dish Dish
    {
        get => _dish;
        set => SetProperty(ref _dish, value);
    }

    public DishViewModel(IDataService dataService)
    {
        _dataService = dataService;
    }

    public int DishId
    {
        get => _dishId;
        set => SetProperty(ref _dishId, value);
    }

    public override async Task Initialize()
    {
        Dish = await _dataService.GetDishAsync(DishId);
        await base.Initialize();
    }
}

