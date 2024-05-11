using Escala.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Escala.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CalendarController : ControllerBase
{
    private readonly CalendarService _calendarService;

    public CalendarController(CalendarService calendarService)
    {
        _calendarService = calendarService;
    }

    [HttpGet("GetHoliday/{year}")]
    public async Task<IActionResult> GetBrazilHoliday(int year)
    {
        var holidays = await _calendarService.GetBrazilHolidays(year);
        return Content(holidays, "application/json");
    }
    
    //TODO: Implementar o método GetDays que consome alguma api que retorne os dias do ano com seus respectivos nomes

    

}