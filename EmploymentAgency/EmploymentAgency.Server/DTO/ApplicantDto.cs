using EmploymentAgency.Domain.Models;
namespace EmploymentAgency.Server.DTO;

public class ApplicantDto : User
{
    public DateOnly Birthday { get; set; }
}
