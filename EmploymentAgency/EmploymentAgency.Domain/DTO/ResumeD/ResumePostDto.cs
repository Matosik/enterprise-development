using EmploymentAgency.Domain.Dto.JobPositionD;

namespace EmploymentAgency.Domain.Dto.ResumeD;
/// <summary>
/// DTO для класса Резюме
/// использоуется для Post
/// </summary>
public class ResumePostDto
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
    public required JobPositionDto Job { get; set; }
    /// <summary>
    /// Желаемая зарплата соискателя
    /// </summary>
    public uint? WantSalary { get; set; }
    /// <summary>
    /// Информация об образовании
    /// </summary>
    public string? Education { get; set; }
}
