using EmploymentAgency.Domain.Models;

namespace EmploymentAgency.Domain.Repositories;

public class RepositoryEmployer : IRepository<Employer>
{
    private int _id = 0;
    private readonly List<Employer> _employers = [];
    public Employer? GetById(int id) => _employers.Find(e => e.IdEmployer == id);

    public IEnumerable<Employer> GetAll() => _employers;

    public void Overwrite(ref Employer old, Employer update)
    {
        old.Number = update.Number;
        old.LastName = update.LastName;
        old.FirstName = update.FirstName;
        old.Company = update.Company;
    }

    public void Post(Employer employer)
    {
        employer.IdEmployer = _id++;
        _employers.Add(employer);
    }
    public bool Delete(int id)
    {
        var employer = GetById(id);
        if (employer == null) { return false; }
        _employers.Remove(employer);
        return true;
    }
}
