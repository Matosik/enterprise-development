namespace EmploymentAgency.Domain.Dto.EmployerDtos;

public class EmployerWithSalaryVacancyDto
{
    public required EmployerGetDto Employerr { get; set; }
    public uint? Salary { get; set; }
}
