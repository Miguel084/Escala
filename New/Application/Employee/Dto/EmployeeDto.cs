namespace Application.Employee.Dto;

public record EmployeeDto(Guid Id, string Name, string Gender, List<LocalDto> Locals);