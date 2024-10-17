namespace EmploymentAgency.Class;

/// <summary>
/// Класс для работодателя
/// </summary>
public class Master : User
{
    public string? Company { get; set; }
    public virtual ICollection<Vacancy> Offers { get; set; } = new List<Vacancy>();
}
