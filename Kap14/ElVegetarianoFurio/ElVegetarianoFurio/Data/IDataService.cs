using System.Collections.Generic;
using System.Threading.Tasks;
using ElVegetarianoFurio.Menu;

namespace ElVegetarianoFurio.Data;

public interface IDataService
{
    Task<List<Category>> GetCategoriesAsync();
    Task<List<Dish>> GetDishesAsync(int? categoryId = null);
    Task<Dish> GetDishAsync(int id);
}