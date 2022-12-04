using LocalDataSample.Models;
using LocalDataSample.Services;
using LocalDataSample.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace LocalDataSample.ViewModels;

public class ItemsViewModel : BaseViewModel<Item>
{
    private Item _selectedItem;

    public ObservableCollection<Item> Items { get; }
    public Command LoadItemsCommand { get; }
    public Command AddItemCommand { get; }
    public Command<Item> ItemTapped { get; }

    public Command DeleteItemCommand { get; }

    public ItemsViewModel(IDataStore<Item> dataStore) : base(dataStore)
    {
        Title = "Data Demo";
        Items = new ObservableCollection<Item>();
        LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        ItemTapped = new Command<Item>(OnItemSelected);

        AddItemCommand = new Command(OnAddItem);
        DeleteItemCommand = new Command(OnDelete);
    }



    async Task ExecuteLoadItemsCommand()
    {
        IsBusy = true;

        try
        {
            Items.Clear();
            var items = await DataStore.GetItemsAsync(true);
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }

    public void Initialize()
    {
        IsBusy = true;
        SelectedItem = null;
    }

    public Item SelectedItem
    {
        get => _selectedItem;
        set
        {
            SetProperty(ref _selectedItem, value);
            OnItemSelected(value);
        }
    }

    private async void OnAddItem(object obj)
    {
        await Shell.Current.GoToAsync(nameof(NewItemPage));
    }

    private async void OnDelete(object item)
    {
        if (item is Item itemToDelete)
        {
            await DataStore.DeleteItemAsync(itemToDelete.Id);
        }
    }

    async void OnItemSelected(Item item)
    {
        if (item == null)
            return;

        // This will push the ItemDetailPage onto the navigation stack
        await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
    }
}