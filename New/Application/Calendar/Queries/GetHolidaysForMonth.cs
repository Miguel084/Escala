using Application.Calendar.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Calendar.Queries;

public record GetHolidaysForMonthQuery(int Year, int Month) : IRequest<IEnumerable<Holiday>>;
public class GetHolidaysForMonth : IRequestHandler<GetHolidaysForMonthQuery, IEnumerable<Holiday>>
{
    private readonly ICalendarService _calendarService;

    public GetHolidaysForMonth(ICalendarService calendarService)
    {
        _calendarService = calendarService;
    }

    public async Task<IEnumerable<Holiday>> Handle(GetHolidaysForMonthQuery request, CancellationToken cancellationToken)
    {
        var holy = await _calendarService.GetBrazilHolidays(request.Year, cancellationToken);
        return holy.Where(x=> x.Date.Month == request.Month);
    }
}
