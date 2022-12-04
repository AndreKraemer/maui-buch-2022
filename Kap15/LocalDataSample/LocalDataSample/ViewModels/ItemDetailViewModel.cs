using LocalDataSample.Models;
using LocalDataSample.Services;
using System.Diagnostics;

namespace LocalDataSample.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel<Item>
    {
        private string _itemId;
        private string _text;
        private string _description;


        public ItemDetailViewModel(IDataStore<Item> dataStore): base(dataStore)
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
            return !string.IsNullOrWhiteSpace(_text)
                   && !string.IsNullOrWhiteSpace(_description);
        }
        public string Id { get; set; }

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public string ItemId
        {
            get => _itemId;
            set
            {
                _itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
                Title = item.Text;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            var itemToUpdate = new Item()
            {
                Id = _itemId,
                Text = _text,
                Description = _description
            };

            await DataStore.UpdateItemAsync(itemToUpdate);

            await Shell.Current.GoToAsync("..");
        }
    }
}
