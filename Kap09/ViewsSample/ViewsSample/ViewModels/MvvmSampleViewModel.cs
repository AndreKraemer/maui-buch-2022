using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ViewsSample.ViewModels;

public class MvvmSampleViewModel : INotifyPropertyChanged
{
    private string _name;
    private string _message;
    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand UpdateMessageCommand { get; set; }

    public MvvmSampleViewModel()
    {
        UpdateMessageCommand = new Command(UpdateMessage, CanUpdateMessage);
    }

    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged();
                (UpdateMessageCommand as Command).ChangeCanExecute();
            }
        }
    }

   
    public string Message
    {
        get => _message;
        set
        {
            if (_message != value)
            {
                _message = value;
                OnPropertyChanged();
            }
        }
    }

    private void UpdateMessage()
    {
        Message = $"{Name} / {DateTime.Now:g}";
    }

    private bool CanUpdateMessage()
    {
        return !string.IsNullOrEmpty(Name);
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
