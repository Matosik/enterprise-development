using EmploymentAgency.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmploymentAgency.Domain.Repositories;
public class RepositoryEmployer(EmploymentAgencyContext context) : IRepository<Employer>
{
    public async Task<List<Employer>> GetAllAsync() => await context.Employers.ToListAsync();
    public async Task<Employer>? GetByIdAsync(int id) => await context.Employers.FirstOrDefaultAsync(e => e.IdEmployer == id);
    public async Task PostAsync(Employer employer)
    {
        employer.Registration = DateTime.UtcNow;
        await context.Employers.AddAsync(employer);
        await context.SaveChangesAsync();
    }
    public async Task<bool> PutAsync(int id, Employer employer)
    {
        var old = await GetByIdAsync(id);
        if (old == null)
            return false;

        context.Entry(old).CurrentValues.SetValues(employer);
        await context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var employer = await GetByIdAsync(id);
        if (employer == null)
            return false;
        context.Employers.Remove(employer);
        await context.SaveChangesAsync();
        return true;
    }
}
