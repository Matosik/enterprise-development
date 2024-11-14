using System.ComponentModel.DataAnnotations;

namespace EmploymentAgency.Domain.DTO.ApplicantD;
/// <summary>
/// 
/// </summary>
public class ApplicantPostDto
{
    /// <summary>
    /// День рождение соискателя
    /// </summary>
    public DateOnly Birthday { get; set; }
    /// <summary>
    /// Контактный номер пользователя
    /// </summary>
    [Phone(ErrorMessage = "Неверный формат номера телефона")]
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
