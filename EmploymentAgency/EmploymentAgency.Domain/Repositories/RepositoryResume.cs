using EmploymentAgency.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmploymentAgency.Domain.Repositories;
public class RepositoryResume(EmploymentAgencyContext context) : IRepository<Resume>
{
    public async Task<List<Resume>> GetAllAsync() => await context.Resumes.ToListAsync();
    public async Task<Resume>? GetByIdAsync(int id) => await context.Resumes.FirstOrDefaultAsync(r => r.IdResume == id);
    public async Task PostAsync(Resume resume)
    {
        await context.Resumes.AddAsync(resume);
        await context.SaveChangesAsync();
    }
    public async Task<bool> PutAsync(int id, Resume resume)
    {
        var old = await GetByIdAsync(id);
        if (old == null)
            return false;

        context.Entry(old).CurrentValues.SetValues(resume);
        await context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var resume = await GetByIdAsync(id);
        if (resume == null)
            return false;
        context.Resumes.Remove(resume);
        await context.SaveChangesAsync();
        return true;
    }
}
