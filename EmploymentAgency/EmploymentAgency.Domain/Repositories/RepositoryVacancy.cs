using EmploymentAgency.Domain.Models;
namespace EmploymentAgency.Domain.Repositories;
public class RepositoryVacancy : IRepository<Vacancy>
{
    private int _id;
    public readonly List<Vacancy> _vacancies;
    public RepositoryVacancy()
    {
        _vacancies = new EmploymentAgencyData().Vacancies;
        _id = _vacancies.Count > 0 ? _vacancies.Max(a => a.IdVacancy) + 1 : 0;
    }
    public IEnumerable<Vacancy> GetAll() => _vacancies;
    public Vacancy? GetById(int id) => _vacancies.Find(v => v.IdVacancy == id);
    public Vacancy Post(Vacancy vacancy)
    {
        vacancy.IdVacancy = _id++;
        _vacancies.Add(vacancy);
        return vacancy;
    }

    public void Overwrite(ref Vacancy old, Vacancy update)
    {
        if (update.DateVacancy != DateTime.MinValue)
        {
            old.DateVacancy = update.DateVacancy;
        }
        if (update != null)
        {
            old.NameVacancy = update.NameVacancy;
        }
        old.Salary = update.Salary;
        old.IsActive = update.IsActive;
        old.Experience = update.Experience;
        old.Summary = update.Summary;
        // old.IdEmployer = update.IdEmployer; по идее же мы не можем изменять/подменять такие данные ?  
        // old.IdJobPosition = update.IdJobPosition;
    }
    public void Delete(Vacancy vacancy)
    {
        _vacancies.Remove(vacancy);
    }
    public bool Delete(int id)
    {
        var vacancy = GetById(id);
        if (vacancy == null) 
            return false; 
        _vacancies.Remove(vacancy);
        return true;
    }
}
