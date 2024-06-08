using Application.Employee.Command;
using Application.Employee.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Escala.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuncionarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public FuncionarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IResult> Create([FromBody] CriarFuncionarioCommand command, CancellationToken cancellationToken)
    {
        var holy = await _mediator.Send(command, cancellationToken);

        return Results.Ok(holy);
    }

    [HttpGet("all")]
    public async Task<IResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllQuery(), cancellationToken);
        var employeeDtos = result.ToList();
        return employeeDtos.Any() ? Results.Ok(employeeDtos) : Results.NotFound();
    }
    
    [HttpGet("all/{id:guid}")]
    public async Task<IResult> GetAllFromId(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllFromIdQuery(id), cancellationToken);
        var employeeDtos = result.ToList();
        return employeeDtos.Any() ? Results.Ok(employeeDtos) : Results.NotFound();
    }
    
    [HttpPut("update")]
    public async Task<IResult> Update([FromForm] UpdateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Results.Ok(result);
    }
}


