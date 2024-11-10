namespace EmploymentAgency.Domain.Models;
/// <summary>
/// Enum заявки на вакансию
/// </summary>
public enum Status
{
    /// <summary>
    /// Отклонено
    /// value = 0 
    /// </summary>
    Rejected,
    /// <summary>
    /// Заявка принята
    /// value = 1
    /// </summary>
    Accepted,
    /// <summary>
    /// Заявка на рассмотрении
    /// value = 2
    /// </summary>
    Requested
}
