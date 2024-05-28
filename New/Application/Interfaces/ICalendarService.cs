
using Application.Calendar.Models;

namespace Application.Interfaces;

public interface ICalendarService
{
    Task<IEnumerable<Holiday>> GetBrazilHolidays(int year,CancellationToken cancellationToken);
}
