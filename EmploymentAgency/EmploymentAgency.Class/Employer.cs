namespace EmploymentAgency.Class;

/// <summary>
/// Класс для работодателя
/// </summary>
public class Employer : User
{
    public int IdEmployer { get; set; }
    public string? Company { get; set; }
}