namespace EmploymentAgency.Class;

/// <summary>
/// Класс Вакансия.
/// </summary>
public class Vacancy
{
    public int IdVacancy { get; set; }
    public int IdEmployer { get; set; }
    public int IdJobPosition { get; set; }
    public string NameVacancy { get; set; }
    /// <summary>
    /// Дата создания вакансии
    /// </summary>
    public DateTime DateVacancy { get; set; }
    public bool IsActive { get; set; }
    public uint? Salary { get; set; }
    /// <summary>
    /// опыть работы в годах
    /// </summary>
    public decimal Experience { get; set; }
    public byte MinAge { get; set; }
    public byte MaxAge { get; set; }
    public string? Summary { get; set; }
}
