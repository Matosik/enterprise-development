using EmploymentAgency.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentAgency.Domain.Repositories;

public class RepositoryEmployer : IRepository<Employer>
{
    private readonly List<Employer> _employers = [];
    public Employer? GetById(int id) => _employers.Find(e => e.IdEmployer == id);

    public IEnumerable<Employer> Gets() => _employers;

    public void Overwrite(ref Employer old, Employer update)
    {
        old.Number = update.Number;
        old.LastName = update.LastName;
        old.FirstName = update.FirstName;
        old.Company = update.Company;
        old.Registration = update.Registration;
    }

    public void Post(Employer employer)
    {
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
