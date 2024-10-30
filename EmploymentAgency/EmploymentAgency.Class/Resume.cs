namespace EmploymentAgency.Class;
/// <summary>
/// Класс резюме
/// </summary>
public class Resume
{
    public int IdResume { get; set; }
    public int IdApplicant { get; set; }
    /// <summary>
    /// Опыт работы в годах
    /// </summary>
    public float Experience { get; set; }
    public int IdPosition { get; set;}
    public uint? WantSalary { get; set; }
    /// <summary>
    /// Информация об образовании
    /// </summary>
    public string? Education { get; set; }
}
