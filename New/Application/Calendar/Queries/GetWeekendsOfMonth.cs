using MediatR;
using System.Globalization;

namespace Application.Calendar.Queries;

public record GetWeekendsOfMonthQuery(int Year, int Month) : IRequest<IEnumerable<string>>;
public class GetWeekendsOfMonth : IRequestHandler<GetWeekendsOfMonthQuery, IEnumerable<string>>
{
    public Task<IEnumerable<string>> Handle(GetWeekendsOfMonthQuery request, CancellationToken cancellationToken)
    {
        var weekends = new List<DateTime>();
        var year = request.Year;
        var month = request.Month;

        DateTime firstDayOfMonth = new DateTime(year, month, 1);
        DateTime lastDayOfMonth = firstDayOfMonth.AddDays(DateTime.DaysInMonth(year, month) - 1);

        var allDaysOfMonth = Enumerable.Range(0, (lastDayOfMonth - firstDayOfMonth).Days + 1)
            .Select(day => firstDayOfMonth.AddDays(day));

        foreach (var day in allDaysOfMonth)
        {
            if (day.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
            {
                weekends.Add(day);
            }
        }


        //var descritivo =  DayOfWeek.Saturday.ToString();


        var cultureInfo = new CultureInfo("pt-BR");
        var weekendsInPtBr = weekends.Select(date => date.ToString("d", cultureInfo));

        return Task.FromResult(weekendsInPtBr);
    }
}
