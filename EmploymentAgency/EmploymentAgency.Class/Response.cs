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
    /// Дато создания отклика
    /// </summary>
    public DateTime DateResponse { get; set; }
    /// <summary>
    /// Номер вакансии, к которой относится отклик
    /// </summary>
    public int IdVacancy { get; set; }
    /// <summary>
    /// Номер Соискателя работы, к который оставил отклик
    /// </summary>
    public int IdApplicant { get; set; }
    /// <summary>
    /// Статус отклика 
    /// <list>
    ///     <item>null - rewiew </item>
    ///     <item>true - accept</item>
    ///     <item>fasle - rejected</item>
    /// </list>   
    /// </summary>
    public bool? ResponseStatus { get; set; }
    /// <summary>
    /// Сообщение соискателя при отклике
    /// </summary>
    public string? SummaryResponse { get; set; }
}
