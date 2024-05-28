namespace Application.Models;

public sealed class ExternalServicesOptions
{
    public const string Section = "ExternalServices";

    public string CalendarApi { get; set; } = string.Empty;
}
