using EmploymentAgency.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EmploymentAgency.Domain.Dto.ResponseDtos;

public class ResponsePostDto
{
    /// <summary>
    /// Номер вакансии, к которой относится отклик
    /// </summary>
    public int IdVacancy { get; set; }
    /// <summary>
    /// Сообщение соискателя при отклике
    /// </summary>
    public string? SummaryResponse { get; set; }
    /// <summary>
    /// Номер резюме, которыей соискатель прикрепил к отклику
    /// </summary>
    public int? IdResume { get; set; }
}
