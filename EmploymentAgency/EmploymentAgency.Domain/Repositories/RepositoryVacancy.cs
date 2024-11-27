using EmploymentAgency.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmploymentAgency.Domain.Repositories;
public class RepositoryVacancy(EmploymentAgencyContext context) : IRepository<Vacancy>
{
    public async Task<List<Vacancy>> GetAllAsync() => await context.Vacancies.ToListAsync();
    public async Task<Vacancy>? GetByIdAsync(int id) => await context.Vacancies.FirstOrDefaultAsync(v => v.IdVacancy == id);
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

        context.Entry(old).CurrentValues.SetValues(vacancy);
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
