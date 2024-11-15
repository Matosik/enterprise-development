namespace EmploymentAgency.Domain.Models;
/// <summary>
/// Класс для отклика 
/// Связывает вакансию и соискателя 
/// </summary>
public class Response
{
    /// <summary>
    /// Уникальный номер отклика
    /// </summary>
    public int IdResponse { get; set; }
    /// <summary>
    /// Дата создания отклика
    /// </summary>
    public DateTime? DateResponse { get; set; }
    /// <summary>
    /// Номер вакансии, к которой относится отклик
    /// </summary>
    public int IdVacancy { get; set; }
    /// <summary>
    /// Номер Соискателя работы, который оставил отклик
    /// </summary>
    
    public int IdApplicant { get; set; }
    /// <summary>
    /// Cтатуса отклика
    /// </summary>
    public required StatusType Status{ get; set; }
    /// <summary>
    /// Сообщение соискателя при отклике
    /// </summary>
    public string? SummaryResponse { get; set; }
    /// <summary>
    /// Номер резюме, которыей соискатель прикрепил к отклику
    /// </summary>
    public int IdResume { get; set; }
}
