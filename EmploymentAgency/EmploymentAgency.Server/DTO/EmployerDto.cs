using EmploymentAgency.Domain.Models;
namespace EmploymentAgency.Server.DTO;

public class EmployerDto : User
{
    public string? Company { get; set; }
}
