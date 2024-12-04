namespace EmploymentAgency.Domain.Dto.JobPositionDtos;

public class JobPositionPutDto
{
    /// <summary>
    /// Раздел (IT, финансы, реклама и т.д.)
    /// </summary>
    public string? Section { get; set; }
    /// <summary>
    /// должность (программист, дизайнер и т.д.)
    /// </summary>
    public string? PositionName { get; set; }
}
