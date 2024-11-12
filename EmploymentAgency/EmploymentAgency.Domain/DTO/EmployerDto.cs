using EmploymentAgency.Domain.Models;
namespace EmploymentAgency.Domain.DTO;
/// <summary>
/// DTO для работадателя
/// </summary>
public class EmployerDto : User
{
    /// <summary>
    /// Название Компании
    /// </summary>
    public string? Company { get; set; }
}
