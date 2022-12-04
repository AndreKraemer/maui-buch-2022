using CollectionViewSamples.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace CollectionViewSamples.ViewModels
{
    public class SelectSampleViewModel : BaseViewModel<Item>
    {
        private Item _selectedItem;
        private string _selectedText = string.Empty;
        private string _tappedText = string.Empty;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<Item> ItemTapped { get; }

        public SelectSampleViewModel()
        {
            Title = "Einträge selektieren";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemTapped);
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

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }


        public string SelectedText
        {
            get => _selectedText;
            set => SetProperty(ref _selectedText, value);
        }
        public string TappedText
        {
            get => _tappedText;
            set => SetProperty(ref _tappedText, value);
        }

        void OnItemSelected(Item item)
        {
            SelectedText = item == null ? "Keine aktive Auswahl" : $"Aktive Auswahl ist: {item.Text}";
        }
        
        void OnItemTapped(Item item)
        {
            TappedText = item == null ? "Es wurde nichts geklickt" : $"Eintrag: {item.Text} wurde geklickt"; 
        }
    }
}