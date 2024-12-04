using EmploymentAgency.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmploymentAgency.Domain.Repositories;
public class RepositoryVacancy(EmploymentAgencyContext context) : IRepository<Vacancy>
{
    public async Task<List<Vacancy>> GetAllAsync() => await context.Vacancies.ToListAsync();
    public async Task<Vacancy?> GetByIdAsync(int id) => await context.Vacancies.FirstOrDefaultAsync(v => v.IdVacancy == id);

    public async Task PostAsync(Vacancy vacancy)
    {
        if (await context.JobPositions.FirstOrDefaultAsync(j => j.IdJobPosition == vacancy.IdJobPosition) == null) // по идее если я правильно понял EF 
            throw new Exception("Не найден JobPosition");                                                          // и так не даст нам добавить объект если на него отсутствует 
        if (await context.Employers.FirstOrDefaultAsync(e=> e.IdEmployer == vacancy.IdEmployer) == null)           // FK, но всё же мы должны это как то обработать или нет ?
            throw new Exception("Не найден Employer");                                                           
        vacancy.DateVacancy = DateTime.UtcNow;                                                                    
        await context.Vacancies.AddAsync(vacancy);
        await context.SaveChangesAsync();
    }                                                                                                             
    public async Task<bool> PutAsync(int id, Vacancy vacancy)
    {
        var old = await GetByIdAsync(id);
        if (old == null)
            return false;

        var properties = typeof(Vacancy).GetProperties()
            .Where
            (
                p => p.Name != nameof(Vacancy.IdVacancy) &&
                p.Name != nameof(Vacancy.DateVacancy) &&
                p.Name != nameof(Vacancy.IdEmployer) &&
                p.Name != nameof(Vacancy.IdJobPosition)
            );

        foreach (var property in properties)
        {
            var newValue = property.GetValue(vacancy);
            if (newValue != null)
                property.SetValue(old, newValue);
        }

        await context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var vacancy = await GetByIdAsync(id);
        if (vacancy == null)
            return false;
        context.Vacancies.Remove(vacancy);
        await context.SaveChangesAsync();
        return true;
    }
}
