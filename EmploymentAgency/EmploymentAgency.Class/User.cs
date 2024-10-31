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
    /// Электронная почта пользователя
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }
    /// <summary>
    /// Контактный номер пользователя
    /// </summary>
    public string? Number { get; set; }
    /// <summary>
    /// Имя Пользователя
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public string LastName { get; set; }

}
