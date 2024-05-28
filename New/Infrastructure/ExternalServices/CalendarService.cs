using Application.Calendar.Models;
using Application.Interfaces;
using System.Text.Json;

namespace Infrastructure.ExternalServices;

public class CalendarService : ICalendarService
{
    private readonly HttpClient _httpClient;

    public CalendarService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Holiday>> GetBrazilHolidays(int year, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync($"api/feriados/v1/{year}", cancellationToken);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<IEnumerable<Holiday>>(content);
    }



}
