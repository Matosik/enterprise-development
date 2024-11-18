using System.ComponentModel.DataAnnotations;

namespace EmploymentAgency.Domain.Dto.ApplicantD;
/// <summary>
/// Пока что данная DTO идентичная классу Applicant, но если в классе Applicant,
/// когда-то появится свойство, которое мы захотим сокрыть от клиентской части
/// то нам пригодится эта DTO-шка
/// </summary>
public class ApplicantGetDto
{
    /// <summary>
    /// Уникальный номер соискателя
    /// </summary>
    public int IdApplicant { get; set; }
    /// <summary>
    /// Дата рождения соискателя
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
