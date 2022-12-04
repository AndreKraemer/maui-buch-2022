using WebserviceSample.Models;
using WebserviceSample.Services;

namespace WebserviceSample.ViewModels;

public class NewSpeakerViewModel : BaseViewModel<Speaker>
{
    private string _name;
    private string _company;
    private string _bio;

    public NewSpeakerViewModel(IDataStore<Speaker> dataStore) : base(dataStore)
    {
        SaveCommand = new Command(OnSave, ValidateSave);
        CancelCommand = new Command(OnCancel);
        this.PropertyChanged +=
            (_, __) => SaveCommand.ChangeCanExecute();
    }

    private bool ValidateSave()
    {
        return !string.IsNullOrWhiteSpace(_name)
            && !string.IsNullOrWhiteSpace(_company)
            && !string.IsNullOrWhiteSpace(_bio);
    }

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public string Company
    {
        get => _company;
        set => SetProperty(ref _company, value);
    }


    public string Bio
    {
        get => _bio;
        set => SetProperty(ref _bio, value);
    }


    public Command SaveCommand { get; }
    public Command CancelCommand { get; }

    private async void OnCancel()
    {
        // This will pop the current page off the navigation stack
        await Shell.Current.GoToAsync("..");
    }

    private async void OnSave()
    {
        Speaker newSpeaker = new Speaker()
        {
            FullName = Name,
            Company = Company,
            Bio = Bio
        };

        await DataStore.AddItemAsync(newSpeaker);

        // This will pop the current page off the navigation stack
        await Shell.Current.GoToAsync("..");
    }
}
