using System.ComponentModel.DataAnnotations;

namespace EmploymentAgency.Server.DTO;

public class EmployerPutDto
{
    /// <summary>
    /// Контактный номер пользователя
    /// </summary>
    [Phone(ErrorMessage = "Неверный формат")]
    public string? Number { get; set; }
    /// <summary>
    /// Имя Пользователя
    /// </summary>
    public required string FirstName { get; set; }
    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public required string LastName { get; set; }
    public string? Company { get; set; }
}
