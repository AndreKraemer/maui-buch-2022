namespace ShellSample;

[QueryProperty(nameof(FirstName), nameof(FirstName))]
[QueryProperty(nameof(LastName), nameof(LastName))]
[QueryProperty(nameof(Age), nameof(Age))]
public partial class NavigationDemoTargetPage : ContentPage //, IQueryAttributable
{

	public NavigationDemoTargetPage()
	{
		InitializeComponent();
	}

	public string FirstName { get; set; }

	public string LastName { get; set; }

	public int Age { get; set; }

	// Alteranativer Weg, falls IQueryAttributable implementiert wird
	//public void ApplyQueryAttributes(IDictionary<string, object> query)
	//{
	//	FirstName = HttpUtility.UrlDecode(query["FirstName"].ToString());
	//	LastName = HttpUtility.UrlDecode(query["LastName"].ToString());
	//	if(int.TryParse(HttpUtility.UrlDecode(query["Age"].ToString()), out int age))
	//	{
	//		Age = age;
	//	}
	//       MessageLabel.Text = $"Ihr Name lautet {FirstName} {LastName}. Sie sind {Age} Jahre alt.";
	//}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
        MessageLabel.Text = $"Ihr Name lautet {FirstName} {LastName}. Sie sind {Age} Jahre alt.";
        base.OnNavigatedTo(args);
	}
}