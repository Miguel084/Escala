using Newtonsoft.Json;

namespace Escala.Api.Models;

public class Holiday
{
    [JsonProperty("date")]
    public DateTime Date { get; set; }

    [JsonProperty("name")]
    public required string Name { get; set; }
    
    [JsonProperty("type")]
    public required string Type { get; set; }
}