using Escala.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Escala.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _employeeService;
    
}