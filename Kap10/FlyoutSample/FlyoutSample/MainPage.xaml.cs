namespace FlyoutSample;

public partial class MainPage : FlyoutPage
{
	public MainPage()
	{
		InitializeComponent();
		FlyoutPage.MenuItemsCollectionView.SelectionChanged += OnSelectionChanged;
	}

	private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
        // prüfen, ob der ausgewählte Eintrag vom korrekten Typ ist
        if (e.CurrentSelection.FirstOrDefault() is MainPageFlyoutMenuItem item)
        {
            // Detailseite erzeugen und die Navigation durchführen
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));

            // Flyout wieder einklappen
            IsPresented = false;
        }
    }
}

