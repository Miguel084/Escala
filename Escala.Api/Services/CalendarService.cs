using Escala.Api.Models;
using Newtonsoft.Json;

namespace Escala.Api.Services
{
    public class CalendarService
    {
        private readonly HttpClient _httpClient;

        public CalendarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<string> GetBrazilHolidays(int year)
        {
            var response = await _httpClient.GetAsync($"https://brasilapi.com.br/api/feriados/v1/{year}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> GetHolidaysForMonth(int year, int month)
        {
            var response = await GetBrazilHolidays(year);
            var holidays = JsonConvert.DeserializeObject<List<Holiday>>(response);
            var holidaysForMonth = (holidays ?? throw new InvalidOperationException()).Where(h => h.Date.Year == year && h.Date.Month == month).ToList();
            var jsonResult = JsonConvert.SerializeObject(holidaysForMonth);
            return jsonResult;
        }
        
        public List<DateTime> GetWeekendsOfMonth(int year, int month)
        {
            var weekends = new List<DateTime>();

            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            var allDaysOfMonth = Enumerable.Range(0, (lastDayOfMonth - firstDayOfMonth).Days + 1)
                .Select(day => firstDayOfMonth.AddDays(day));

            foreach (var day in allDaysOfMonth)
            {
                if (day.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
                {
                    weekends.Add(day);
                }
            }

            return weekends;
        }
    }
}