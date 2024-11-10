using System.ComponentModel.DataAnnotations;
namespace EmploymentAgency.Server.DTO;
/// <summary>
/// DTO для изменения данных Соискателя/кандидата
/// </summary>
public class ApplicantPutDto
{
    /// <summary>
    /// Контактный номер пользователя
    /// </summary>
    [Phone(ErrorMessage = "Неправильно набран номер")]
    public string? Number { get; set; }
    /// <summary>
    /// Имя Пользователя
    /// </summary>
    public required string FirstName { get; set; }
    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public required string LastName { get; set; }
}
