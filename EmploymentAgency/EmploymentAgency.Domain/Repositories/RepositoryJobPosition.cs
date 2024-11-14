using EmploymentAgency.Domain.DTO;
using EmploymentAgency.Domain.Models;

namespace EmploymentAgency.Domain.Repositories;

public class RepositoryJobPosition : IRepository<JobPosition>
{
    private int _id;
    private readonly List<JobPosition> _jobs = [];
    public RepositoryJobPosition()
    {
        _jobs = new EmploymentAgencyData().Jobs;
        _id = _jobs.Count > 0 ? _jobs.Max(a => a.IdJobPosition) + 1 : 0;
    }
    public JobPosition? GetById(int id) => _jobs.Find(j => j.IdJobPosition == id);

    public IEnumerable<JobPosition> GetAll() => _jobs;

    public void Overwrite(ref JobPosition old, JobPosition update)
    {
        old.Section = update.Section;
        old.PositionName = update.PositionName;
    }
    public JobPosition Post(JobPosition jobPosition)
    {
        jobPosition.IdJobPosition = _id++;
        _jobs.Add(jobPosition);
        return jobPosition;
    }
    public void Delete(JobPosition job)
    {
        _jobs.Remove(job);
    }
    public bool Delete(int id)
    {
        var job = GetById(id);
        if (job == null) 
            return false; 
        Delete(job);
        return true;
    }
}
