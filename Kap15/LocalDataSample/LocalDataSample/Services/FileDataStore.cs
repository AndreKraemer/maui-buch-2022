using LocalDataSample.Models;

namespace LocalDataSample.Services;

public class FileDataStore : IDataStore<Item>
{
    
    private readonly string _folder =
        Path.Combine(FileSystem.AppDataDirectory, "notes");
       // Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "notes");


    public FileDataStore()
    {
        if (!Directory.Exists(_folder))
        {
            Directory.CreateDirectory(_folder);
        }
    }

    public Task<bool> AddItemAsync(Item item)
    {
        var fileName = Path.Combine(_folder, $"{item.Id}.txt");
        File.WriteAllText(fileName, $"{item.Text}{Environment.NewLine}{item.Description}" );
        return Task.FromResult(true);
    }

    public Task<bool> UpdateItemAsync(Item item)
    {
        item.Id = Guid.NewGuid().ToString();
        var fileName = Path.Combine(_folder, $"{item.Id}.txt");
        File.WriteAllText(fileName, $"{item.Text}{Environment.NewLine}{item.Description}");
        return Task.FromResult(true);
    }

    public Task<bool> DeleteItemAsync(string id)
    {
        var fileName = Path.Combine(_folder, $"{id}.txt");

        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        return Task.FromResult(true);
    }

    public Task<Item> GetItemAsync(string id)
    {
        var fileName = Path.Combine(_folder, $"{id}.txt");

        if (File.Exists(fileName))
        {
            var content = File.ReadAllLines(fileName);
            var item = new Item
            {
                Id = Path.GetFileNameWithoutExtension(fileName),
                Text = content[0],
                Description = string.Concat(content.Skip(1))
            };
            return Task.FromResult(item);
        }

        return null;
    }

    public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
    {
        var result = new List<Item>();
        var files = Directory.GetFiles(_folder);
        foreach (var file in files)
        {
           result.Add(await GetItemAsync(Path.GetFileNameWithoutExtension(file)));
        }

        return result;
    }
}