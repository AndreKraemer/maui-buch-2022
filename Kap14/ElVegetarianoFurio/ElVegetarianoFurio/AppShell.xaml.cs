using ElVegetarianoFurio.Menu;

namespace ElVegetarianoFurio;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(CategoryPage), typeof(CategoryPage));
        Routing.RegisterRoute(nameof(DishPage), typeof(DishPage));
    }
}
