using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ElVegetarianoFurio.Menu;
using Newtonsoft.Json;

namespace ElVegetarianoFurio.Data
{
    public class JsonDataService : IDataService
    {
        private RestaurantData _data;
        private async Task<RestaurantData> GetRestaurantData()
        {
            if (_data != null)
            {
                return _data;
            }
            //var assembly = IntrospectionExtensions.GetTypeInfo(GetType()).Assembly;
            var assembly = GetType().Assembly;

            var stream = assembly.GetManifestResourceStream("ElVegetarianoFurio.Data.db.json");

            string json;

            using (var reader = new StreamReader(stream))
            {
                json = await reader.ReadToEndAsync();
            }

            _data = JsonConvert.DeserializeObject<RestaurantData>(json);
            return _data;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var data = await GetRestaurantData();
            return data.Categories;
        }

        public async Task<List<Dish>> GetDishesAsync(int? categoryId = null)
        {
            var dishes = (await GetRestaurantData()).Dishes;

            if (categoryId.HasValue)
            {
                dishes = dishes.Where(d => d.CategoryId == categoryId).ToList();
            }

            return dishes;
        }

        public async Task<Dish> GetDishAsync(int id)
        {
            var dishes = (await GetRestaurantData()).Dishes;
            return dishes.SingleOrDefault(d => d.Id == id);
        }

        private class RestaurantData
        {
            public List<Category> Categories { get; set; }
            public List<Dish> Dishes { get; set; }
        }
    }
}