using CollectionViewSamples.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace CollectionViewSamples.ViewModels
{
    public class RefreshSampleViewModel : BaseViewModel<Item>
    {

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }

        public RefreshSampleViewModel()
        {
            Title = "Daten aktualisieren";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
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
        public override Task Initialize()
        {
            IsBusy = true;
            return base.Initialize();
        }
    }
}