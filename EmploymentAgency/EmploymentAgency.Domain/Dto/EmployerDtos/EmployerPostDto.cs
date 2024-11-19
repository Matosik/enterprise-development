using System.ComponentModel.DataAnnotations;

namespace EmploymentAgency.Domain.Dto.EmployerD;
/// <summary>
/// DTO для Post Employer
/// </summary>
public class EmployerPostDto
{
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
    /// <summary>
    /// Название компании
    /// </summary>
    public string? Company { get; set; }
}
