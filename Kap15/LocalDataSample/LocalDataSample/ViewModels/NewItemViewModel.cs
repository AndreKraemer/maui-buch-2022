using LocalDataSample.Models;
using LocalDataSample.Services;

namespace LocalDataSample.ViewModels;

public class NewItemViewModel : BaseViewModel<Item>
{
    private string text;
    private string description;

    public NewItemViewModel(IDataStore<Item> dataStore) : base(dataStore)
    {
        SaveCommand = new Command(OnSave, ValidateSave);
        CancelCommand = new Command(OnCancel);
        this.PropertyChanged +=
            (_, __) => SaveCommand.ChangeCanExecute();
    }

    private bool ValidateSave()
    {
        return !string.IsNullOrWhiteSpace(text)
            && !string.IsNullOrWhiteSpace(description);
    }

    public string Text
    {
        get => text;
        set => SetProperty(ref text, value);
    }

    public string Description
    {
        get => description;
        set => SetProperty(ref description, value);
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
        Item newItem = new Item()
        {
            Id = Guid.NewGuid().ToString(),
            Text = Text,
            Description = Description
        };

        await DataStore.AddItemAsync(newItem);

        // This will pop the current page off the navigation stack
        await Shell.Current.GoToAsync("..");
    }
}
