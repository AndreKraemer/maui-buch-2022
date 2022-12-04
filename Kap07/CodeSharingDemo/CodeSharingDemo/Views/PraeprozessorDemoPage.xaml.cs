using static System.Net.Mime.MediaTypeNames;

namespace CodeSharingDemo.Views;

public partial class PraeprozessorDemoPage : ContentPage
{
    public PraeprozessorDemoPage()
    {
        InitializeComponent();
        // var text = GetDeviceName(); 
        var text = "";
#if __ANDROID__
        // Dieser Code wird nur unter Android
        // in die App hineinkompiliert.
        text = Android.OS.Build.Device;
#elif __IOS__ 
        // Dieser Code wird nur unter iOS oder macOS
        // in die App hineinkompiliert.
        text = UIKit.UIDevice.CurrentDevice.Name;

#elif WINDOWS
        // Dieser Code wird nur unter Windows
        // in die App hineinkompiliert
        var deviceInformation = new Windows.Security
            .ExchangeActiveSyncProvisioning.EasClientDeviceInformation();
        text = deviceInformation.FriendlyName;
#endif
        DeviceInfoLabel.Text = text;

    }
    
#if __ANDROID__
    private string GetDeviceName()
    {
        return Android.OS.Build.Device;
    }
#endif

#if __IOS__
    private string GetDeviceName()
    {
        return UIKit.UIDevice.CurrentDevice.Name;
    }
#endif

#if WINDOWS
    private string GetDeviceName()
    {
        var deviceInformation = new Windows.Security
            .ExchangeActiveSyncProvisioning.EasClientDeviceInformation();
        return deviceInformation.FriendlyName;
    }
#endif

}