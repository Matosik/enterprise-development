using System.ComponentModel.DataAnnotations;

namespace EmploymentAgency.Domain.Dto.ApplicantD;
/// <summary>
/// DTO изменения Applicant
/// нельзя изменить дату рождения 
/// нельзя  дату регистрации
/// </summary>
public class ApplicantPutDto
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
}
