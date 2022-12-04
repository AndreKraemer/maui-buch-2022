using WebserviceSample.ViewModels;
namespace WebserviceSample.Views
{
    public partial class SpeakersPage : ContentPage
    {
        readonly SpeakersViewModel _viewModel;

        public SpeakersPage(SpeakersViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = _viewModel = viewModel;
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            _viewModel.Initialize();

            base.OnNavigatedTo(args);
        }
    }
}