using EmploymentAgency.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EmploymentAgency.Domain.Dto.ResponseDtos;
/// <summary>
/// DTO для изменения данных класса Отклика
/// </summary
public class ResponsePutDto
{
    /// <summary>
    ///  Cтатуса отклика
    /// </summary>
    [EnumDataType(typeof(StatusType))]
    public string? Status { get; set; }
    /// <summary>
    /// Сообщение соискателя при отклике
    /// </summary>
    public string? SummaryResponse { get; set; }
}
