using System.Text.Json.Serialization;

namespace Application.Calendar.Models;

public class Holiday
{

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }


    [JsonPropertyName("type")]
    public string Type { get; set; }
}
