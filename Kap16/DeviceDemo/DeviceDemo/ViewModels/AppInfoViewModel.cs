namespace DeviceDemo.ViewModels;

public class AppInfoViewModel : BaseViewModel
{
    public AppInfoViewModel(IAppInfo appInfo)
    {
        Name = appInfo.Name;
        Version = appInfo.VersionString;
    }

    public string Name { get; }

    public string Version { get; }
}
