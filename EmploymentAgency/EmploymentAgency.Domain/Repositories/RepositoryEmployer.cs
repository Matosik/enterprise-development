using EmploymentAgency.Domain.Models;

namespace EmploymentAgency.Domain.Repositories;

public class RepositoryEmployer : IRepository<Employer>
{
    private int _id ;
    private readonly List<Employer> _employers = [];
    public RepositoryEmployer()
    {
        _employers = new EmploymentAgencyData().Employers;
        _id = _employers.Count > 0 ? _employers.Max(a => a.IdEmployer) + 1 : 0;
    }
    public Employer? GetById(int id) => _employers.Find(e => e.IdEmployer == id);
    public IEnumerable<Employer> GetAll() => _employers;

    public void Overwrite(ref Employer old, Employer update)
    {
        old.Number = update.Number;
        old.LastName = update.LastName;
        old.FirstName = update.FirstName;
        old.Company = update.Company;
    }

    public Employer Post(Employer employer)
    {
        employer.IdEmployer = _id++;
        _employers.Add(employer);
        return employer;
    }
    public void Delete(Employer employer)
    {
        _employers.Remove(employer);
    }
    public bool Delete(int id)
    {
        var employer = GetById(id);
        if (employer == null) 
            return false; 
        _employers.Remove(employer);
        return true;
    }
}
