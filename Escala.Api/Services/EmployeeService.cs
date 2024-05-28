using Escala.DataBase.Data.DbContexts;
using Escala.DataBase.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Escala.Api.Services;

public class EmployeeService
{
    private readonly ApplicationDbContext _context;
    
    public EmployeeService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<List<EmployeeDTO>> GetAllEmployees()
    {
        return await _context.employee.ToListAsync();
    }
    
}