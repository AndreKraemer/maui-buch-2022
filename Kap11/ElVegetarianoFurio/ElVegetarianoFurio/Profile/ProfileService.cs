namespace ElVegetarianoFurio.Profile;

public class ProfileService : IProfileService
{
    private Profile _profile = new Profile();
    public Task<Profile> GetAsync()
    {
        return Task.FromResult(_profile);
    }

    public async Task<bool> SaveAsync(Profile profile)
    {
        _profile = profile;
        await Task.Delay(3000); // Demo
        return true;
    }
}