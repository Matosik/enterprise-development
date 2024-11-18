using EmploymentAgency.Domain.Models;
namespace EmploymentAgency.Domain.Repositories;
public class RepositoryVacancy : IRepository<Vacancy>
{
    private int _id;
    private readonly List<Vacancy> _vacancies;
    private IRepository<RepositoryResponse> _repositoryResponse;
    public RepositoryVacancy(IRepository<RepositoryResponse> repositoryResponse)
    {
        _repositoryResponse = repositoryResponse;
        _vacancies = new EmploymentAgencyData().Vacancies;
        _id = _vacancies.Count > 0 ? _vacancies.Max(a => a.IdVacancy) + 1 : 0;
    }
    public IEnumerable<Vacancy> GetAll() => _vacancies;
    public Vacancy? GetById(int id) => _vacancies.Find(v => v.IdVacancy == id);
    public Vacancy Post(Vacancy vacancy)
    {
        vacancy.DateVacancy = DateTime.UtcNow;
        vacancy.IdVacancy = _id++;
        _vacancies.Add(vacancy);
        return vacancy;
    }

    public void Overwrite(ref Vacancy old, Vacancy update)
    {
        
        old.DateVacancy = update.DateVacancy;
        old.NameVacancy = update.NameVacancy;
        old.Salary = update.Salary;
        old.IsActive = update.IsActive;
        old.Experience = update.Experience;
        old.Summary = update.Summary;
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
