using CollectionViewSamples.ViewModels;
using Microsoft.Maui.Controls;


namespace CollectionViewSamples.Views
{

    public partial class MenuSamplePage : ContentPage
    {
        private MenuSampleViewModel _viewModel;

        public MenuSamplePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MenuSampleViewModel();
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            await _viewModel.Initialize();
            base.OnNavigatedTo(args);
        }
    }
}