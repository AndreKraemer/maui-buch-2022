namespace ElVegetarianoFurio.Profile;

public class ProfileService : IProfileService
{

    private readonly IPreferences _preferences;

    public ProfileService(IPreferences preferences)
    {
        _preferences = preferences;
    }
    public Task<Profile> GetAsync()
    {
        var profile = new Profile
        {
            City = _preferences.Get(nameof(Profile.City), ""),
            FullName = _preferences.Get(nameof(Profile.FullName), ""),
            Phone = _preferences.Get(nameof(Profile.Phone), ""),
            Street = _preferences.Get(nameof(Profile.Street), ""),
            Zip = _preferences.Get(nameof(Profile.Zip), "")
        };
        return Task.FromResult(profile);
    }

    public async Task<bool> SaveAsync(Profile profile)
    {
        Preferences.Set(nameof(Profile.City), profile.City);
        Preferences.Set(nameof(Profile.FullName), profile.FullName);
        Preferences.Set(nameof(Profile.Phone), profile.Phone);
        Preferences.Set(nameof(Profile.Street), profile.Street);
        Preferences.Set(nameof(Profile.Zip), profile.Zip);

        await Task.Delay(3000); // Ladezeiten simulieren
        return true;
    }
}