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
    
    [HttpGet("GetHolidaysForMonth/{year}/{month}")]
    public async Task<IActionResult> GetHolidaysForMonth(int year, int month)
    {
        var holidays = await _calendarService.GetHolidaysForMonth(year, month);
        return Content(holidays, "application/json");
    }
    

}