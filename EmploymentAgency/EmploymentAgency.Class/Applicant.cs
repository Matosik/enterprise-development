namespace EmploymentAgency.Class;

/// <summary>
///  Класс для соискателя работы
/// </summary>
public class Applicant : User
{
    public int IdApplicant { get; set; }
    public DateOnly Birthday { get; set; }
    public int Age { get; set; }
}
