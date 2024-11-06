namespace EmploymentAgency.Class;
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
    /// ID статуса отклика
    /// </summary>
    public int IdStatus{ get; set; }
    /// <summary>
    /// Сообщение соискателя при отклике
    /// </summary>
    public string? SummaryResponse { get; set; }
}
