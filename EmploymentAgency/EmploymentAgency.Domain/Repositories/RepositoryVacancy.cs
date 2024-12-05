using EmploymentAgency.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmploymentAgency.Domain.Repositories;
public class RepositoryVacancy(EmploymentAgencyContext context) : IRepository<Vacancy>
{
    public async Task<List<Vacancy>> GetAllAsync() => await context.Vacancies.ToListAsync();
    public async Task<Vacancy?> GetByIdAsync(int id) => await context.Vacancies.FirstOrDefaultAsync(v => v.IdVacancy == id);

    public async Task PostAsync(Vacancy vacancy)
    {                                                       
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
