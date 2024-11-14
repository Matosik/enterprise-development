namespace EmploymentAgency.Domain.DTO.JobPositionD;

/// <summary>
/// DTO для Рабочей позиции
/// </summary>
public class JobPositionDto
{
    /// <summary>
    /// Раздел (IT, финансы, реклама и т.д.)
    /// </summary>
    public string? Section { get; set; }
    /// <summary>
    /// должность (программист, дизайнер и т.д.)
    /// </summary>
    public required string PositionName { get; set; }
}
