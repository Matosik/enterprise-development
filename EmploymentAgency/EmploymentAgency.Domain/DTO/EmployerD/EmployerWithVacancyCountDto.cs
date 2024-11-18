namespace EmploymentAgency.Domain.Dto.EmployerD;
public class EmployerWithVacancyCountDto
{
    public required EmployerGetDto Employer { get; set; }
    public int Count { get; set; }
}
