using EmploymentAgency.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmploymentAgency.Domain.Repositories;
public class RepositoryResponse(EmploymentAgencyContext context) : IRepository<Response>
{
    public async Task<List<Response>> GetAllAsync() => await context.Responses.ToListAsync();
    public async Task<Response>? GetByIdAsync(int id) => await context.Responses.FirstOrDefaultAsync(r => r.IdResponse == id);
    public async Task PostAsync(Response response)
    {
        response.DateResponse = DateTime.UtcNow;
        await context.Responses.AddAsync(response);
        await context.SaveChangesAsync();
    }
    public async Task<bool> PutAsync(int id, Response response)
    {
        var old = await GetByIdAsync(id);
        if (old == null)
            return false;

        context.Entry(old).CurrentValues.SetValues(response);
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
