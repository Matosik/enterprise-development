namespace EmploymentAgency.Domain.Dto.VacancyDtos;

public class VacancyGetDto
{
    /// <summary>
    /// Уникальный номер вакансии
    /// </summary>
    public int IdVacancy { get; set; }
    /// <summary>
    /// Номер Работодателя который разместил вакансию
    /// </summary>
    public int IdEmployer { get; set; }
    /// <summary>
    /// Номер рабочей позиции
    /// </summary>
    public int IdJobPosition { get; set; }
    /// <summary>
    /// Название вакансии
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
