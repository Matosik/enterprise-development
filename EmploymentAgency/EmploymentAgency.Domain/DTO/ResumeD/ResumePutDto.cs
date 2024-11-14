namespace EmploymentAgency.Domain.DTO.ResumeD;

/// <summary>
/// DTO для изменения данных класса Резюме
/// использоуется для Put
/// не можем поменять ID соискателя работы
/// </summary
public class ResumePutDto
{
    /// <summary>
    /// Опыт работы в годах
    /// </summary>
    public float Experience { get; set; }
    /// <summary>
    ///  Номер рабочей позиции на которой работал соискатель
    /// </summary>
    public int IdPosition { get; set; } // Можно по идее сделать тип JobPosition, но оставлю так нарочно
    /// <summary>
    /// Желаемая зарплата соискателя
    /// </summary>
    public uint? WantSalary { get; set; }
    /// <summary>
    /// Информация об образовании
    /// </summary>
    public string? Education { get; set; }
}
