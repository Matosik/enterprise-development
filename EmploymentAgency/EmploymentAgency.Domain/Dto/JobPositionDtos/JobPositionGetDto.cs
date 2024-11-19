namespace EmploymentAgency.Domain.Dto.JobPositionDtos;
public class JobPositionGetDto
{
    /// <summary>
    /// Уникальный номер рабочей позции 
    /// </summary>
    public int IdJobPosition { get; set; }
    /// <summary>
    /// Раздел (IT, финансы, реклама и т.д.)
    /// </summary>
    public string? Section { get; set; }
    /// <summary>
    /// должность (программист, дизайнер и т.д.)
    /// </summary>
    public required string PositionName { get; set; }
}
