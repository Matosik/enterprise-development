
namespace EmploymentAgency.Domain.Dto.ResumeDtos;
/// <summary>
/// Данная DTO идентичная классу Resume, но если в классе Resume,
/// когда-то появится свойство, которое мы захотим сокрыть от клиентской части
/// то нам пригодится эта DTO-шка
/// </summary>
public class ResumeGetDto
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
