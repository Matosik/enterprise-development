namespace EmploymentAgency.Class;
/// <summary>
/// Класс резюме
/// </summary>
public class Resume
{
    /// <summary>
    ///  Уникальный номер резюме
    /// </summary>
    public int IdResume { get; set; }
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
    public int IdPosition { get; set;}
    /// <summary>
    /// Желаемая зарплата соискателя
    /// </summary>
    public uint? WantSalary { get; set; }
    /// <summary>
    /// Информация об образовании
    /// </summary>
    public string? Education { get; set; }
}
