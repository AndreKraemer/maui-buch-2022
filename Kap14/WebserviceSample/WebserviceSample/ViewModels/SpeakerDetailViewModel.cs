using System.Diagnostics;
using WebserviceSample.Models;
using WebserviceSample.Services;


namespace WebserviceSample.ViewModels;

[QueryProperty(nameof(SpeakerId), nameof(SpeakerId))]
public class SpeakerDetailViewModel : BaseViewModel<Speaker>
{
    private int _speakerId;
    private string _name;
    private string _bio;
    private string _company;

    public SpeakerDetailViewModel(IDataStore<Speaker> dataStore) : base(dataStore)
    {

        SaveCommand = new Command(OnSave, ValidateSave);
        CancelCommand = new Command(OnCancel);
        this.PropertyChanged +=
            (_, __) => SaveCommand.ChangeCanExecute();
    }

    public Command CancelCommand { get; set; }

    public Command SaveCommand { get; set; }

    private bool ValidateSave()
    {
        return !string.IsNullOrWhiteSpace(_name)
               && !string.IsNullOrWhiteSpace(_company)
               && !string.IsNullOrWhiteSpace(_bio);
    }

    public int Id { get; set; }

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public string Bio
    {
        get => _bio;
        set => SetProperty(ref _bio, value);
    }

    public string Company
    {
        get => _company;
        set => SetProperty(ref _company, value);
    }

    public int SpeakerId
    {
        get => _speakerId;
        set
        {
            _speakerId = value;
            LoadSpeaker(value);
        }
    }

    public async void LoadSpeaker(int speakerId)
    {
        try
        {
            var item = await DataStore.GetItemAsync(speakerId);
            Id = item.Id;
            Name = item.FullName;
            Company = item.Company;
            Bio = item.Bio;
        }
        catch (Exception)
        {
            Debug.WriteLine("Failed to Load Speaker");
        }
    }

    private async void OnCancel()
    {
        // This will pop the current page off the navigation stack
        await Shell.Current.GoToAsync("..");
    }

    private async void OnSave()
    {
        var itemToUpdate = new Speaker()
        {
            Id = Id,
            FullName = Name,
            Company = Company,
            Bio = Bio
        };

        await DataStore.UpdateItemAsync(itemToUpdate);

        // This will pop the current page off the navigation stack
        await Shell.Current.GoToAsync("..");
    }
}
