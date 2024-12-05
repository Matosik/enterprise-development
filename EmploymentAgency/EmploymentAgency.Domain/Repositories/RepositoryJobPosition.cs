using EmploymentAgency.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmploymentAgency.Domain.Repositories;
public class RepositoryJobPosition(EmploymentAgencyContext context) : IRepository<JobPosition>
{
    public async Task<List<JobPosition>> GetAllAsync() => await context.JobPositions.ToListAsync();
    public async Task<JobPosition?> GetByIdAsync(int id) => await context.JobPositions.FirstOrDefaultAsync(j => j.IdJobPosition == id);
    public async Task PostAsync(JobPosition jobPosition)
    {
        await context.JobPositions.AddAsync(jobPosition);
        await context.SaveChangesAsync();
    }
    public async Task<bool> PutAsync(int id, JobPosition jobPosition)
    {
        var old = await GetByIdAsync(id);
        if (old == null)
            return false;

        var properties = typeof(JobPosition).GetProperties()
            .Where
            (
                p => p.Name != nameof(JobPosition.IdJobPosition) 
            );

        foreach (var property in properties)
        {
            var newValue = property.GetValue(jobPosition);
            if (newValue != null)
                property.SetValue(old, newValue);
        }
        await context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var jobPosition = await GetByIdAsync(id);
        if (jobPosition == null)
            return false;
        context.JobPositions.Remove(jobPosition);
        await context.SaveChangesAsync();
        return true;
    }
}
