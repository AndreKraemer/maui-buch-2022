using WebserviceSample.Views;

namespace WebserviceSample;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(SpeakerDetailPage), typeof(SpeakerDetailPage));
        Routing.RegisterRoute(nameof(NewSpeakerPage), typeof(NewSpeakerPage));

    }
}
