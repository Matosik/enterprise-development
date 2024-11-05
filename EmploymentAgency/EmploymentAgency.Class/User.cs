using System.ComponentModel.DataAnnotations;

namespace EmploymentAgency.Class;
/// <summary>
/// Базовый класс пользователь
/// </summary>
public class User
{
    /// <summary>
    /// Дата регистрации пользователя
    /// </summary>
    public DateTime Registration { get; set; }
    /// <summary>
    /// Контактный номер пользователя
    /// </summary>
    [Phone]
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
