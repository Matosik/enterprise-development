namespace EmploymentAgency.Domain.Repositories;

public interface IRepository<TEntity, TDto>
{
    public Task<List<TEntity>> GetAllAsync();
    public Task<TEntity>? GetByIdAsync(int id);
    public Task PostAsync(TEntity entity);
    public Task PostAsync(TDto entity);
    //public void Overwrite(ref TEntity old, TEntity update);
    public Task<bool> PutAsync(int id, TEntity entity);
    public Task<bool> DeleteAsync(int id);
}