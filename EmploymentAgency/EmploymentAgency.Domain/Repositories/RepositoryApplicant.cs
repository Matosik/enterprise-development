using EmploymentAgency.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentAgency.Domain.Repositories;

internal class RepositoryApplicant : IRepository<Applicant>
{
    private readonly List<Applicant> _applicants = [];
    public IEnumerable<Applicant> Gets() => _applicants;
    public Applicant? GetById(int id) => _applicants.Find(v => v.IdApplicant == id);
    public void Post(Applicant entity)
    {
        _applicants.Add(entity);
    }
    public void Overwrite(ref Applicant old, Applicant update)
    {
        old.Birthday = update.Birthday;
        old.Number = update.Number;
        old.Registration = update.Registration;
        old.FirstName = update.FirstName;
        old.LastName = update.LastName;
    }
    public bool Delete(int id)
    {
        var vacancy = GetById(id);
        if (vacancy == null) { return false; }
        _applicants.Remove(vacancy);
        return true;
    }
}
