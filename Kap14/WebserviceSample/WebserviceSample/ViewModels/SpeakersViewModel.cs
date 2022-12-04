using System.Collections.ObjectModel;
using System.Diagnostics;
using WebserviceSample.Models;
using WebserviceSample.Services;
using WebserviceSample.Views;


namespace WebserviceSample.ViewModels
{
    public class SpeakersViewModel : BaseViewModel<Speaker>
    {
        private Speaker _selectedSpeaker;

        public ObservableCollection<Speaker> Speakers { get; }
        public Command LoadSpeakersCommand { get; }
        public Command AddSpeakerCommand { get; }

        public Command DeleteSpeakerCommand { get; }
        public Command<Speaker> SpeakerTapped { get; }

        public SpeakersViewModel(IDataStore<Speaker> dataStore) : base(dataStore)
        {
            Title = "Liste der Konferenzsprecher";
            Speakers = new ObservableCollection<Speaker>();
            LoadSpeakersCommand = new Command(async () => await ExecuteLoadItemsCommand());

            SpeakerTapped = new Command<Speaker>(OnItemSelected);

            AddSpeakerCommand = new Command(OnAddItem);

            DeleteSpeakerCommand = new Command(OnDelete);
        }

        private async void OnDelete(object item)
        {
            if (item is Speaker itemToDelete)
            {
                await DataStore.DeleteItemAsync(itemToDelete.Id);
            }
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Speakers.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Speakers.Add(item);
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
            SelectedSpeaker = null;
        }

        public Speaker SelectedSpeaker
        {
            get => _selectedSpeaker;
            set
            {
                SetProperty(ref _selectedSpeaker, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewSpeakerPage));
        }

        async void OnItemSelected(Speaker speaker)
        {
            if (speaker == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(SpeakerDetailPage)}?{nameof(SpeakerDetailViewModel.SpeakerId)}={speaker.Id}");
        }
    }
}