using EmploymentAgency.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EmploymentAgency.Server.DTO;
/// <summary>
/// DTO для изменения данных класса Отклика
/// </summary
public class ResponsePutDto
{
    /// <summary>
    ///  Cтатуса отклика
    /// </summary>
    [EnumDataType(typeof(StatusType))]
    public required string Status { get; set; }
    /// <summary>
    /// Сообщение соискателя при отклике
    /// </summary>
    public string? SummaryResponse { get; set; }
}
