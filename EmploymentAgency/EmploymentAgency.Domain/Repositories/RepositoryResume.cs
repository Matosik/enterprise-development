using EmploymentAgency.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentAgency.Domain.Repositories;

public class RepositoryResume : IRepository<Resume>
{
    private int _id = 0;
    private readonly List<Resume> _resumes = [];
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

    public void Post(Resume entity)
    {
        _resumes.Add(entity);
    }
    public bool Delete(int id)
    {
        var resume = GetById(id);
        if(resume == null) { return false; }
        _resumes.Remove(resume);
        return true;
    }
}
