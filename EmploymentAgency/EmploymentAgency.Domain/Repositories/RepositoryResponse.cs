using EmploymentAgency.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmploymentAgency.Domain.Repositories;
public class RepositoryResponse(EmploymentAgencyContext context) : IRepository<Response>
{
    public async Task<List<Response>> GetAllAsync() => await context.Responses.ToListAsync();
    public async Task<Response?> GetByIdAsync(int id) => await context.Responses.FirstOrDefaultAsync(r => r.IdResponse == id);
    public async Task PostAsync(Response response)
    {
        if (await context.Applicants.FirstOrDefaultAsync(a => a.IdApplicant == response.IdApplicant) == null)
            throw new Exception("Applicant с таким ID не найден");
        if (await context.Vacancies.FirstOrDefaultAsync(r => r.IdVacancy == response.IdVacancy) == null)
            throw new Exception("Вакансяи с таким ID не найдена");
        response.Status = StatusType.Requested;
        response.DateResponse = DateTime.UtcNow;
        await context.Responses.AddAsync(response);
        await context.SaveChangesAsync();
    }
    public async Task<bool> PutAsync(int id, Response response)
    {
        var old = await GetByIdAsync(id);
        if (old == null)
            return false;

        var properties = typeof(Response).GetProperties()
            .Where
            (
                p => 
                p.Name != nameof(Response.IdVacancy) &&
                p.Name != nameof(Response.IdApplicant) &&
                p.Name != nameof(Response.DateResponse) &&
                p.Name != nameof(Response.IdResponse) &&
                p.Name != nameof(Response.IdResume)
            );

        foreach (var property in properties)
        {
            var newValue = property.GetValue(response);
            if (newValue != null)
                property.SetValue(old, newValue);
        }

        await context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var response = await GetByIdAsync(id);
        if (response == null)
            return false;
        context.Responses.Remove(response);
        await context.SaveChangesAsync();
        return true;
    }
}
