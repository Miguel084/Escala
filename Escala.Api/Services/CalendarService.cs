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
        
        /// <summary>
        /// Esse metoodo retorna os feriados do Brasil
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
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
    }
}