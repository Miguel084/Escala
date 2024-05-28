using Application.Funcionario.Dto;
using Application.Interfaces;
using Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Funcionario.Command;

public record CriarFuncionarioCommand(string Name, string Gender, List<UnidadeDto>? Unidades) : IRequest<int>;
internal class CriarFuncionario : IRequestHandler<CriarFuncionarioCommand, int>
{
    private readonly IApplicationDbContext _dbContext;

    public CriarFuncionario(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(CriarFuncionarioCommand request, CancellationToken cancellationToken)
    {

        var local = request.Unidades?.Select(x => new Domain.Entitites.Local
        {
            Id = x.Id,
            Nome = x.Nome
        }).ToList();

        var func = new Employee
        {
            Gender = request.Gender,
            Name = request.Name,
            Local = local
        };

        await _dbContext.Employees.AddAsync(func, cancellationToken);

        return _dbContext.SaveChanges();
    }
}
