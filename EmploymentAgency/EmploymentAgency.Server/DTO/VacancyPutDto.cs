namespace EmploymentAgency.Server.DTO;

public class VacancyPutDto
{
    /// <summary>
    /// Номер рабочей позиции
    /// </summary>
    public int IdJobPosition { get; set; }
    /// <summary>
    /// Название вакансии
    /// </summary>
    public required string NameVacancy { get; set; }
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
