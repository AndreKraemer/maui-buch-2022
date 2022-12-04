namespace ElVegetarianoFurio.Contact;

public partial class ContactPage : ContentPage
{
	public ContactPage(ContactViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}