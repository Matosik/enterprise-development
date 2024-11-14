using EmploymentAgency.Domain.DTO.JobPositionD;
using EmploymentAgency.Domain.Models;

namespace EmploymentAgency.Domain.DTO.VacancyD;

/// <summary>
/// DTO для изменения данных класса Вакансия
/// Запрещено менять JobPosition 
/// </summary
public class VacancyPutDto
{
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
