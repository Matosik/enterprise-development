namespace EmploymentAgency.Domain.Models;
/// <summary>
/// Класс статус заявки на вакансию
/// </summary>
public class Status
{
    /// <summary>
    /// Уникальный номер статуса
    /// </summary>
    public int IdStatus { get; set; }
    /// <summary>
    /// Имя статуса
    /// </summary>
    public required string StatusName { get; set; }
}
