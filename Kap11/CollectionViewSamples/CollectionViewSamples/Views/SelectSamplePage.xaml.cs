using CollectionViewSamples.ViewModels;
using Microsoft.Maui.Controls;


namespace CollectionViewSamples.Views
{

    public partial class SelectSamplePage : ContentPage
    {
        private SelectSampleViewModel _viewModel;

        public SelectSamplePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new SelectSampleViewModel();
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            await _viewModel.Initialize();
            base.OnNavigatedTo(args);
        }
    }
}