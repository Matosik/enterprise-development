namespace EmploymentAgency.Class;

public class JobPosition
{
    public int Id { get; set; }
    /// <summary>
    /// Раздел (IT, финансы, реклама и т.д.)
    /// </summary>
    public string Section { get; set; }
    /// <summary>
    /// должность (программист, дизайнер и т.д.)
    /// </summary>
    public string PositionName { get; set; }
}
