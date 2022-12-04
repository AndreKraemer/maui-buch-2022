using System.Threading.Tasks;

namespace ElVegetarianoFurio.Profile;

public interface IProfileService
{
    Task<Profile> GetAsync();
    Task<bool> SaveAsync(Profile profile);
}