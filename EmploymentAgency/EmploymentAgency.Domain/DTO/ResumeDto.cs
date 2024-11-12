namespace EmploymentAgency.Domain.DTO;

/// <summary>
/// DTO для класса Резюме
/// </summary
public class ResumeDto
{
    /// <summary>
    /// Номер соискателя к которому относится резюме
    /// </summary>
    public int IdApplicant { get; set; }
    /// <summary>
    /// Опыт работы в годах
    /// </summary>
    public float Experience { get; set; }
    /// <summary>
    ///  Номер рабочей позиции на которой работал соискатель
    /// </summary>
    public int IdPosition { get; set; }
    /// <summary>
    /// Желаемая зарплата соискателя
    /// </summary>
    public uint? WantSalary { get; set; }
    /// <summary>
    /// Информация об образовании
    /// </summary>
    public string? Education { get; set; }
}
