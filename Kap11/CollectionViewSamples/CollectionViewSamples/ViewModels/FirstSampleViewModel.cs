using CollectionViewSamples.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace CollectionViewSamples.ViewModels
{
    public class FirstSampleViewModel : BaseViewModel<Item>
    {

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public FirstSampleViewModel()
        {
            Title = "Ein einfaches Beispiel";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
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
    }
}