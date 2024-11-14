using EmploymentAgency.Domain.Models;

namespace EmploymentAgency.Domain.Repositories;

public class RepositoryResume : IRepository<Resume>
{
    private int _id;
    private readonly List<Resume> _resumes = [];
    public RepositoryResume()
    {
        _resumes = new EmploymentAgencyData().Resumes;
        _id = _resumes.Count > 0 ? _resumes.Max(a => a.IdResume) + 1 : 0;
    }
    public Resume? GetById(int id) => _resumes.Find(r => r.IdResume == id);

    public IEnumerable<Resume> GetAll() => _resumes;

    public void Overwrite(ref Resume old, Resume update)
    {
        old.Education = update.Education;
        old.IdPosition = update.IdPosition; // Организовать проверку существует ли такой IDPosition
        old.IdApplicant = update.IdApplicant; // Организовать проверку существует ли такой IdApplicant
        old.Experience = update.Experience;
        old.WantSalary = update.WantSalary;
    }

    public Resume Post(Resume resume)
    {
        resume.IdPosition = _id++;
        _resumes.Add(resume);
        return resume;
    }
    public void Delete(Resume resume)
    {
        _resumes.Remove(resume);
    }
    public bool Delete(int id)
    {
        var resume = GetById(id);
        if (resume == null) 
            return false;
        Delete(resume);
        return true;
    }
}
