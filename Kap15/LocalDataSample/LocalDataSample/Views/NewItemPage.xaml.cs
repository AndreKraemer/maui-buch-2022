using LocalDataSample.Models;
using LocalDataSample.ViewModels;

namespace LocalDataSample.Views;

public partial class NewItemPage : ContentPage
{
    public NewItemPage(NewItemViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}