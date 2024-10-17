namespace EmploymentAgency.Class;

public class Resume
{
    public int Id { get; set; }
    public int IdSlave { get; set; }
    /// <summary>
    /// Опыт работы в годах
    /// </summary>
    public decimal Exp { get; set; }
    public JobPosition? Position { get; set; }
    public uint? WantSalary { get; set; }
    public string? Summary { get; set; }
}
