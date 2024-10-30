namespace EmploymentAgency.Class;
/// <summary>
/// Класс для отклика 
/// Связывает вакансию и соискателя 
/// </summary>
public class Response
{
    public int IdResponse { get; set; }
    public DateTime DateResponse { get; set; }
    public int IdVacancy { get; set; }
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
