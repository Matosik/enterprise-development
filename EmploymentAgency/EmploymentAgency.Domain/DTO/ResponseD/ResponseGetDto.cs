

using EmploymentAgency.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EmploymentAgency.Domain.DTO.ResponseD;

public class ResponseGetDto
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
    [EnumDataType(typeof(StatusType))]
    public required string Status { get; set; }
    /// <summary>
    /// Сообщение соискателя при отклике
    /// </summary>
    public string? SummaryResponse { get; set; }
}
