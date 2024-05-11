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

        //TODO: Implementar o método GetDays que consome alguma api que retorne os dias do ano com seus respectivos nomes
        // public async Task<string> GetDays(int year)
        // {
        //     
        // }
    }
}