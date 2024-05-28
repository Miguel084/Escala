using Application.Calendar.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Escala.Server.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CalendarController : ControllerBase
{
    private readonly IMediator _mediator;

    public CalendarController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("holidays/{year:int}")]
    public async Task<IResult> GetHolidays([FromRoute] int year, CancellationToken cancellationToken)
    {
        var holy = await _mediator.Send(new GetHolidaysQuery(year), cancellationToken);

        return Results.Ok(holy);
    }

    [HttpGet("holidays/{year:int}/mes/{month:int}")]
    public async Task<IResult> GetHolidays([FromRoute] int year, int month, CancellationToken cancellationToken)
    {
        var holy = await _mediator.Send(new GetHolidaysForMonthQuery(year, month), cancellationToken);

        return Results.Ok(holy);
    }

    [HttpGet("weekends/mes/{month:int}/ano/{year:int}")]
    public async Task<IResult> GetWeekends([FromRoute] int year, int month, CancellationToken cancellationToken)
    {
        var holy = await _mediator.Send(new GetWeekendsOfMonthQuery(year, month), cancellationToken);

        return Results.Ok(holy);
    }

}
