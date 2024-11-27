using System.ComponentModel.DataAnnotations;

namespace EmploymentAgency.Domain.Models;

/// <summary>
///  Класс для соискателя работы, наследуемый от User
/// </summary>
public class Applicant : User
{
    /// <summary>
    /// Уникальный номер соискателя
    /// </summary>
    [Key]
    public int IdApplicant { get; set; }
    /// <summary>
    /// Дата рождения соискателя
    /// </summary>
    public DateOnly Birthday { get; set; }
}
