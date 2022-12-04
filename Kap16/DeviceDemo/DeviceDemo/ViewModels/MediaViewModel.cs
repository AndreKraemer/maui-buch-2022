namespace DeviceDemo.ViewModels;

public class MediaViewModel : BaseViewModel
{
    private ImageSource _image;
    private readonly IMediaPicker _mediaPicker;

    public Command OpenGalleryCommand { get; }
    public Command OpenCameraCommand { get; }


    public MediaViewModel(IMediaPicker mediaPicker)
    {
        _mediaPicker = mediaPicker;
        OpenGalleryCommand = new Command(OnGalleryClicked);
        OpenCameraCommand = new Command(OnCameraClicked);
    }

    public ImageSource Image
    {
        get => _image;
        set => SetProperty(ref _image, value);
    }

    private async void OnGalleryClicked()
    {
        // Foto auswählen
        var result = await _mediaPicker.PickPhotoAsync();
        // Ergebnis auslesen
        var stream = await result.OpenReadAsync();
        // Ergebnisstream zur Anzeige an die Eigenschaft Image übergeben
        Image = ImageSource.FromStream(() => stream);
    }

    private async void OnCameraClicked()
    {
        // Foto aufnehmen (Funktioniert derzeit unter WinUI nicht!)
        var result = await _mediaPicker.CapturePhotoAsync();
        // Ergebnis auslesen
        if (result != null)
        {
            var stream = await result.OpenReadAsync();
            // Ergebnisstream zur Anzeige an die Eigenschaft Image übergeben
            Image = ImageSource.FromStream(() => stream);
        }
    }
}

