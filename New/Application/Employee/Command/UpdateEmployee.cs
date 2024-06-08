using System.Net;
using Application.Employee.Dto;
using Application.Interfaces;
using MediatR;

namespace Application.Employee.Command;

public record UpdateEmployeeCommand(Guid Id, string Name, string Gender, List<LocalDto>? Locals) : IRequest<int>;
internal class UpdateEmployee : IRequestHandler<UpdateEmployeeCommand, int>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateEmployee(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = _dbContext.Employees.Find(request.Id);

        if (employee == null)
        {
            // throw new NotFoundException(nameof(Employee), request.Id);
        }

        employee.Name = request.Name;
        employee.Gender = request.Gender;

        if (request.Locals != null)
        {
            employee.Locals = request.Locals.Select(x => new Domain.Entitites.Local
            {
                Id = x.Id,
                Nome = x.Nome
            }).ToList();

        }
        _dbContext.Employees.Update(employee);
        
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}