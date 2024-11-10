using EmploymentAgency.Domain.Models;

namespace EmploymentAgency.Server.DTO;

public class ResponseDto
{
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
    public Status Stat { get; set; }
    /// <summary>
    /// Сообщение соискателя при отклике
    /// </summary>
    public string? SummaryResponse { get; set; }
}
