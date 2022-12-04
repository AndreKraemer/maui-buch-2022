using System.Collections.ObjectModel;
using LocalDataSample.Models;


namespace LocalDataSample.ViewModels;

public class FoldersViewModel : BaseViewModel
{
    public ObservableCollection<Folder> Folders { get; } =
        new ObservableCollection<Folder>();


    public void Initialize()
    {
        InitializeFolderCollection();
    }

    private void InitializeFolderCollection()
    {
        try
        {
            IsBusy = true;
            Folders.Clear();
            Folders.Add(new Folder(".NET MAUI AppDataDirectory", FileSystem.AppDataDirectory));
            Folders.Add(new Folder(".NET MAUI CacheDirectory", FileSystem.CacheDirectory));

            foreach (var folder in Enum.GetValues(typeof(Environment.SpecialFolder)))
            {
                var folderPath = Environment.GetFolderPath((Environment.SpecialFolder) folder);
                if (!string.IsNullOrEmpty(folderPath))
                {
                    Folders.Add(new Folder(folder.ToString(), folderPath));
                }
            }
        }
        finally
        {
            IsBusy = false;
        }
    }
}
