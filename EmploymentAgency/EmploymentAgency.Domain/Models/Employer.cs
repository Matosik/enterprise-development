namespace EmploymentAgency.Domain.Models;

/// <summary>
/// Класс для работодателя, наследуемый от User
/// </summary>
public class Employer : User
{
    /// <summary>
    /// Уникальный номер работодателя
    /// </summary>
    public int IdEmployer { get; set; }
    /// <summary>
    /// Название компании которую представляет работоатель
    /// </summary>
    public string? Company { get; set; }
}