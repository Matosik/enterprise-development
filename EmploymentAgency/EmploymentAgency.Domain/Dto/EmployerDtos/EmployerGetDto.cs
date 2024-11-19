using System.ComponentModel.DataAnnotations;

namespace EmploymentAgency.Domain.Dto.EmployerDtos;
/// <summary>
/// 
/// </summary>
public class EmployerGetDto
{
    /// <summary>
    /// Уникальный номер работодателя
    /// </summary>
    public int IdEmployer { get; set; }
    /// <summary>
    /// Название компании которую представляет работоатель
    /// </summary>
    public string? Company { get; set; }
    /// <summary>
    /// Дата регистрации пользователя
    /// </summary>
    public DateTime? Registration { get; set; }
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
