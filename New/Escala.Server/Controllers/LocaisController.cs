using Application.Local.Commands;
using Application.Local.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Escala.Server.Controllers;


[Route("api/[controller]")]
[ApiController]
public class LocaisController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocaisController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("incluir")]
    public async Task<IResult> Incluir([FromForm] CadastrarLocalCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Results.Ok(result);
    }


    [HttpGet("all")]
    public async Task<IResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllQuery(), cancellationToken);
        var localDtos = result.ToList();
        return localDtos.Any() ? Results.Ok(localDtos) : Results.NotFound();
    }
}
