
using System.Text.Json.Serialization;

namespace WebserviceSample.Models;

public class Speaker
{
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string FullName { get; set; }
    public string Company { get; set; }
    public string Bio { get; set; }
}