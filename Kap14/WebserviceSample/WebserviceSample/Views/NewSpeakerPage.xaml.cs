using WebserviceSample.Models;
using WebserviceSample.ViewModels;

namespace WebserviceSample.Views
{
    public partial class NewSpeakerPage : ContentPage
    {

        public NewSpeakerPage(NewSpeakerViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}