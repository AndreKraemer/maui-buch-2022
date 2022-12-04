using ElVegetarianoFurio.Core;

namespace ElVegetarianoFurio.Profile;

public class ProfileViewModel : BaseViewModel
{
    private readonly IProfileService _service;

    private string _city = string.Empty;
    private string _fullName = string.Empty;
    private string _phone = string.Empty;
    private string _street = string.Empty;
    private string _zip = string.Empty;

    public ProfileViewModel(IProfileService service)
    {
        _service = service;
        Title = "Mein Profil";
        SaveCommand = new Command(Save, CanSave);
    }

    private bool CanSave()
    {
        return !IsBusy;
    }

    public string FullName
    {
        get => _fullName;
        set => SetProperty(ref _fullName, value);
    }

    public string Street
    {
        get => _street;
        set => SetProperty(ref _street, value);
    }

    public string Zip
    {
        get => _zip;
        set => SetProperty(ref _zip, value);
    }

    public string City
    {
        get => _city;
        set => SetProperty(ref _city, value);
    }

    public string Phone
    {
        get => _phone;
        set => SetProperty(ref _phone, value);
    }

    public Command SaveCommand { get; }

    public override async Task Initialize()
    {
        try
        {
            IsBusy = true;
            await base.Initialize();
            var profile = await _service.GetAsync();
            FullName = profile.FullName;
            Street = profile.Street;
            Zip = profile.Zip;
            City = profile.City;
            Phone = profile.Phone;
        }
        finally
        {
            await Task.Delay(10000); // Nur zu Demozwecken!
            IsBusy = false;
        }
    }

    private async void Save()
    {
        //if(IsBusy)
        //{
        //    return;
        //}
        try
        {
            IsBusy = true;
            SaveCommand.ChangeCanExecute();
            var profile = new Profile
            {
                FullName = FullName,
                Street = Street,
                Zip = Zip,
                City = City,
                Phone = Phone
            };

            await _service.SaveAsync(profile);
        }
        finally
        {
            IsBusy = false;
            SaveCommand.ChangeCanExecute();
        }
    }
}