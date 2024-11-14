using EmploymentAgency.Domain.Models;
namespace EmploymentAgency.Domain.Repositories;

public class RepositoryApplicant : IRepository<Applicant>
{
    private int _id;
    private readonly List<Applicant> _applicants= [];
    public RepositoryApplicant()
    {
        _applicants = new EmploymentAgencyData().Applicants;
        _id = _applicants.Count > 0 ? _applicants.Max(a => a.IdApplicant) + 1 : 0;
    }
    public IEnumerable<Applicant> GetAll() => _applicants;
    public Applicant? GetById(int id) => _applicants.Find(v => v.IdApplicant == id);
    public Applicant Post(Applicant applicant)
    {
        applicant.IdApplicant = _id++;
        _applicants.Add(applicant);
        return applicant;
    }
    public void Overwrite(ref Applicant old, Applicant update)
    {
        if (update.Birthday != DateOnly.MinValue)
        {
            old.Birthday = update.Birthday;
        }
        old.Number = update.Number;
        if (update.Registration != null)
        {
            old.Registration = update.Registration;
        }
        old.FirstName = update.FirstName;
        old.LastName = update.LastName;
    }
    public void Delete(Applicant applicant)
    {
        _applicants.Remove(applicant);
    }
    public bool Delete(int id)
    {
        var applicant = GetById(id);
        if (applicant == null) 
            return false; 
        _applicants.Remove(applicant);
        return true;
    }
}
