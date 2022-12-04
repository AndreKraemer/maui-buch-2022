using CollectionViewSamples.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace CollectionViewSamples.ViewModels
{
    public class MenuSampleViewModel : BaseViewModel<Item>
    {
        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<Item> DeleteItemCommand { get; }

        public MenuSampleViewModel()
        {
            Title = "Kontextmenüs";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            DeleteItemCommand = new Command<Item>(OnItemDeleted);
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
            finally
            {
                IsBusy = false;
            }
        }

        public override async Task Initialize()
        {
            await ExecuteLoadItemsCommand();
            await base.Initialize();
        }


        async void OnItemDeleted(Item item)
        {
            if (item != null)
            {
                if (await DataStore.DeleteItemAsync(item.Id))
                {
                    Items.Remove(item);
                };
            }
        }
    }
}