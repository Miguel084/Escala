using Newtonsoft.Json;
public class Holiday
{
    [JsonProperty("date")]
    public DateTime Date { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
}