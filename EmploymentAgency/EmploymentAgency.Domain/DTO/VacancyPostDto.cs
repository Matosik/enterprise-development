namespace EmploymentAgency.Domain.DTO;

public class VacancyPostDto
{
    /// <summary>
    /// Номер Работодателя который разместил вакансию
    /// </summary>
    public int IdEmployer { get; set; } 
    /// <summary>
    /// Название рабочей позиции
    /// </summary>
    public JobPositionDto Job { get; set; }
    /// <summary>
    /// Название рабочей 
    /// </summary>
    public required string NameVacancy { get; set; }
    /// <summary>
    /// Дата создания вакансии
    /// </summary>
    public DateTime DateVacancy { get; set; }
    /// <summary>
    /// Статус вакансии активна/неактивна
    /// </summary>
    public bool IsActive { get; set; }
    /// <summary>
    /// Зарплата на данную вакансию
    /// </summary>
    public uint? Salary { get; set; }
    /// <summary>
    /// Опыть работы в годах
    /// </summary>
    public float Experience { get; set; }
    /// <summary>
    ///  Описание вакансии
    /// </summary>
    public string? Summary { get; set; }
}
