namespace LocalDataSample.Models;

public class Folder
{
    public Folder()
    {
        
    }
    public Folder(string name, string location)
    {
        Name = name;
        Location = location;
    }

    public string Name { get; set; }
    public string Location { get; set; }
}