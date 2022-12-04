namespace ElVegetarianoFurio.Core;

public class NavigationService : INavigationService
{
    public async Task GoToAsync(string location)
    {
        await Shell.Current.GoToAsync(location);
    }

    public async Task GoToAsync(string location, bool animate)
    {
        await Shell.Current.GoToAsync(location, animate);
    }

    public async Task GoToAsync(string location, Dictionary<string, object> paramters)
    {
        await Shell.Current.GoToAsync(location, paramters);
    }

    public async Task GoToAsync(string location, bool animate, Dictionary<string, object> paramters)
    {
        await Shell.Current.GoToAsync(location, animate, paramters);
    }
}


