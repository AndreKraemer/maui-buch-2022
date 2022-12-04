using CollectionViewSamples.ViewModels;
using Microsoft.Maui.Controls;


namespace CollectionViewSamples.Views
{

    public partial class RefreshSamplePage : ContentPage
    {
        private RefreshSampleViewModel _viewModel;

        public RefreshSamplePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new RefreshSampleViewModel();
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            await _viewModel.Initialize();
            base.OnNavigatedTo(args);
        }
    }
}