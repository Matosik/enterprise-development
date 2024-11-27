﻿using EmploymentAgency.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmploymentAgency.Domain.Repositories;
public class RepositoryApplicant(EmploymentAgencyContext context) : IRepository<Applicant>
{
    public async Task<List<Applicant>> GetAllAsync() => await context.Applicants.ToListAsync();
    public async Task<Applicant>? GetByIdAsync(int id) => await context.Applicants.FirstOrDefaultAsync(a => a.IdApplicant == id);
    public async Task PostAsync(Applicant applicant)
    {
        applicant.Registration = DateTime.UtcNow;
        await context.Applicants.AddAsync(applicant);
        await context.SaveChangesAsync();
    }
    public async Task<bool> PutAsync(int id, Applicant applicant)
    {
        var old = await GetByIdAsync(id);
        if (old == null)
            return false;

        context.Entry(old).CurrentValues.SetValues(applicant);
        await context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var applicant = await GetByIdAsync(id);
        if (applicant == null)
            return false;
        context.Applicants.Remove(applicant);
        await context.SaveChangesAsync();
        return true;
    }
}
