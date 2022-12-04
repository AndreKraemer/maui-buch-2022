using CollectionViewSamples.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace CollectionViewSamples.ViewModels
{
    public class GroupSampleViewModel : BaseViewModel<Item>
    {

        public ObservableCollection<ItemGroup> Items { get; }
        public Command LoadItemsCommand { get; }
        public GroupSampleViewModel()
        {
            Title = "Gruppierte Einträge";
            Items = new ObservableCollection<ItemGroup>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);

                var group = new List<ItemGroup>
                {
                    new ItemGroup("Group 1", items.Take(3).ToList()),
                    new ItemGroup("Group 2", items.Skip(3).Take(3).ToList())
                };

                foreach (var item in group)
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