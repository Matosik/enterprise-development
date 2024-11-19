namespace EmploymentAgency.Domain.Dto.EmployerDtos;
public class EmployerWithVacancyCountDto
{
    public required EmployerGetDto Employer { get; set; }
    public int Count { get; set; }
}
