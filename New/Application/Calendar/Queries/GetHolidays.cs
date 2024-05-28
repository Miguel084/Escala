using Application.Calendar.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Calendar.Queries;


public record GetHolidaysQuery(int Year) : IRequest<IEnumerable<Holiday>>;
public class GetHolidays : IRequestHandler<GetHolidaysQuery, IEnumerable<Holiday>>
{
    private readonly ICalendarService _calendar;

    public GetHolidays(ICalendarService calendar)
    {
        _calendar = calendar;
    }

    public async Task<IEnumerable<Holiday>> Handle(GetHolidaysQuery request, CancellationToken cancellationToken)
    {
        var holidays = await _calendar.GetBrazilHolidays(request.Year, cancellationToken);
        return holidays;

    }
}
