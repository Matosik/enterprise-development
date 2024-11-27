using System.ComponentModel.DataAnnotations;

namespace EmploymentAgency.Domain.Models;
/// <summary>
/// Класс для определения должности
/// </summary>
public class JobPosition
{
    /// <summary>
    /// Уникальный номер рабочей позции 
    /// </summary>
    [Key]
    public int IdJobPosition { get; set; }
    /// <summary>
    /// Раздел (IT, финансы, реклама и т.д.)
    /// </summary>
    public string?Section { get; set; }
    /// <summary>
    /// должность (программист, дизайнер и т.д.)
    /// </summary>
    public required string PositionName { get; set; }
}
 