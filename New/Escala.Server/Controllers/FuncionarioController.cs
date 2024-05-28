using Application.Funcionario.Command;
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
}


