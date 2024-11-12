using EmploymentAgency.Domain.Models;
namespace EmploymentAgency.Domain.DTO;

/// <summary>
/// DTO для Соискателя/кандидата
/// </summary>
public class ApplicantDto : User
{
    /// <summary>
    /// День рождение соискателя
    /// </summary>
    public DateOnly Birthday { get; set; }
}
