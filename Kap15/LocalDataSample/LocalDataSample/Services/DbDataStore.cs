using LocalDataSample.Models;
using SQLite;

namespace LocalDataSample.Services;

public class DbDataStore : IDataStore<Item>
{

    private const SQLiteOpenFlags SqliteFlags =
        SQLiteOpenFlags.ReadWrite |
        SQLiteOpenFlags.Create |
        SQLiteOpenFlags.SharedCache;

    private static readonly string DatabasePath =
        Path.Combine(FileSystem.AppDataDirectory, "items.db3");

    private static SQLiteAsyncConnection _database;


    public DbDataStore()
    {
        _database = new SQLiteAsyncConnection(DatabasePath, SqliteFlags);
        _database.CreateTableAsync<Item>().Wait();
    }

    /// <summary>
    /// Fügt einen Eintrag zur Tabelle Item hinzu
    /// </summary>
    public async Task<bool> AddItemAsync(Item item)
    {
        item.Id = Guid.NewGuid().ToString();
        return await _database.InsertAsync(item) == 1;
    }

    /// <summary>
    /// Aktualisiert einen Eintrag
    /// </summary>
    public async Task<bool> UpdateItemAsync(Item item)
    {
        return await _database.UpdateAsync(item) == 1;
    }

    /// <summary>
    /// Löscht einen Eintrag anhand seiner Id
    /// </summary>
    public async Task<bool> DeleteItemAsync(string id)
    {
        return await _database.DeleteAsync<Item>(id) == 1;
    }

    /// <summary>
    /// Liefert einen Eintrag aus der Tabelle Item zurück
    /// </summary>
    public async Task<Item> GetItemAsync(string id)
    {
        return await _database.Table<Item>()
            .Where(s => s.Id == id)
            .FirstOrDefaultAsync();
    }

    /// <summary>
    /// Gibt alle Datensätze der Tabelle Item zurück
    /// </summary>
    public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
    {
        return await _database.Table<Item>().ToListAsync();
    }
}