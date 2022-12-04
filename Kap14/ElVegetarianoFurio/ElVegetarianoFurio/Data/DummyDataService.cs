using ElVegetarianoFurio.Menu;

namespace ElVegetarianoFurio.Data;
public class DummyDataService : IDataService
{
    private readonly List<Category> _categories;
    private readonly List<Dish> _dishes;

    public DummyDataService()
    {
        _categories
            = new List<Category>
            {
                    new Category { Id = 1, Name = "Ensaladas", Description = "Salate" },
                    new Category { Id = 2, Name = "Cremas y sopas", Description = "Suppen" },
                    new Category { Id = 3, Name = "Tapas", Description = "Kleine Portionen" },
                    new Category { Id = 4, Name = "Platos principales", Description = "Hauptgerichte" },
                    new Category { Id = 5, Name = "Postres", Description = "Desserts" },
                    new Category { Id = 6, Name = "Bebidas", Description = "Getränke" }
            };

        _dishes = new List<Dish>
            {
                new Dish
                {
                    Id = 1,
                    Name = "Ensalada de Casa",
                    Description = "Salat nach Art des Hauses. Gemischter Salat, Mais, Paprika, Käse, Zwiebeln",
                    Price = 3.49m,
                    CategoryId = 1
                },
                new Dish
                {
                    Id = 2,
                    Name = "Ensalada furia",
                    Description = "Gemischter Salat mit Chillis, Paprika, Radieschen und Zwiebeln (scharf!)",
                    Price = 3.99m,
                    CategoryId = 1
                },
                new Dish
                {
                    Id = 3,
                    Name = "Sopa de Tomate",
                    Description = "Tomatensuppe",
                    Price = 3.29m,
                    CategoryId = 2
                },
                new Dish
                {
                    Id = 4,
                    Name = "Crema de verduras",
                    Description = "Gemüsecremesuppe",
                    Price = 4.39m,
                    CategoryId = 2
                },
                new Dish
                {
                    Id = 5,
                    Name = "Tortilla de patatas",
                    Description = "Spanisches Omlett aus Eiern und Kartoffeln",
                    Price = 4.99m,
                    CategoryId = 3
                },
                new Dish
                {
                    Id = 6,
                    Name = "Patatas bravas",
                    Description = "Gebratene Kartoffelstücke in pikanter Sauce",
                    Price = 3.99m,
                    CategoryId = 3
                },
                new Dish
                {
                    Id = 7,
                    Name = "Pimientos al grill",
                    Description = "Gegrillte Paprika",
                    Price = 2.99m,
                    CategoryId = 3
                },
                new Dish
                {
                    Id = 8,
                    Name = "Pan con alioli",
                    Description = "Ailoli mit Brot",
                    Price = 2.29m,
                    CategoryId = 3
                },
                new Dish
                {
                    Id = 9,
                    Name = "Pan con tomate y ajo",
                    Description = "Brot mit Tomate und Knoblauch",
                    Price = 2.29m,
                    CategoryId = 3
                },
                new Dish
                {
                    Id = 10,
                    Name = "Tortilla Chips",
                    Description = "Tortilla Chips mit Salsa Dip, Guacamole oder Alioli",
                    Price = 1.29m,
                    CategoryId = 3
                },
                new Dish
                {
                    Id = 11,
                    Name = "Chilli sin carne",
                    Description = "Vegetarisches Chilli, serviert mit Reis",
                    Price = 5.39m,
                    CategoryId = 4
                },
                new Dish
                {
                    Id = 12,
                    Name = "Enchiladas de verduras",
                    Description = "Überbackene Maistortillas gefüllt mit Gemüse",
                    Price = 4.99m,
                    CategoryId = 4
                },
                new Dish
                {
                    Id = 13,
                    Name = "Burritos de verduras",
                    Description = "Weizentortillas gefüllt mit Gemüse",
                    Price = 4.99m,
                    CategoryId = 4
                },
                new Dish
                {
                    Id = 14,
                    Name = "Arroz con verduras",
                    Description = "Reis-/Gemüsepfanne",
                    Price = 4.49m,
                    CategoryId = 4
                },
                new Dish
                {
                    Id = 15,
                    Name = "Empanadas de espinacas y maíz",
                    Description = "Teigtaschen gefüllt mit Spinat und Mais",
                    Price = 4.49m,
                    CategoryId = 4
                },
                new Dish
                {
                    Id = 16,
                    Name = "Crema Catalana",
                    Description = "Katalanische Creme",
                    Price = 2.49m,
                    CategoryId = 5
                },
                new Dish
                {
                    Id = 17,
                    Name = "Ensalada de frutas",
                    Description = "Obstsalat mit frischen Früchten",
                    Price = 2.99m,
                    CategoryId = 5
                },
                new Dish
                {
                    Id = 18,
                    Name = "Churros",
                    Description = "Spritzgebäck mit Zucker",
                    Price = 1.99m,
                    CategoryId = 5
                },
                new Dish
                {
                    Id = 19,
                    Name = "Agua mineral",
                    Description = "Mineralwasser",
                    Price = 1.59m,
                    CategoryId = 6
                },
                new Dish
                {
                    Id = 20,
                    Name = "Zumo de manzana",
                    Description = "Apfelsaft",
                    Price = 1.59m,
                    CategoryId = 6
                },
                new Dish
                {
                    Id = 21,
                    Name = "Limonada",
                    Description = "Zitronenlimonade",
                    Price = 1.59m,
                    CategoryId = 6
                },
                new Dish
                {
                    Id = 22,
                    Name = "Café",
                    Description = "Kaffee",
                    Price = 1.59m,
                    CategoryId = 6
                }
            };
    }

    public Task<List<Category>> GetCategoriesAsync()
    {
        return Task.FromResult(_categories);
    }

    public Task<List<Dish>> GetDishesAsync(int? categoryId = null)
    {
        return categoryId.HasValue
            ? Task.FromResult(_dishes.Where(d => d.CategoryId == categoryId).ToList())
            : Task.FromResult(_dishes);
    }

    public Task<Dish> GetDishAsync(int id)
    {
        return Task.FromResult(_dishes.SingleOrDefault(d => d.Id == id));
    }
}