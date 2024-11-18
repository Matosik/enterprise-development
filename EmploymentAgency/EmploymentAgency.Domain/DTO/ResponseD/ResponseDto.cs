using EmploymentAgency.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EmploymentAgency.Domain.Dto.ResponseD;

/// <summary>
/// DTO для отклика
/// </summary>
public class ResponseDto
{
    /// <summary>
    /// Номер вакансии, к которой относится отклик
    /// </summary>
    public int IdVacancy { get; set; }
    /// <summary>
    /// Дата создания отклика
    /// </summary>
    public DateTime? DateResponse { get; set; }
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
    /// <summary>
    /// Номер резюме, которыей соискатель прикрепил к отклику
    /// </summary>
    public int IdResume { get; set; }
}
