using EmploymentAgency.Domain.Models;

namespace EmploymentAgency.Domain.Repositories;

public class RepositoryJobPosition : IRepository<JobPosition>
{
    private int _id = 0;
    private readonly List<JobPosition> _jobs = [];

    public JobPosition? GetById(int id) => _jobs.Find(j => j.IdJobPosition == id);

    public IEnumerable<JobPosition> GetAll() => _jobs;

    public void Overwrite(ref JobPosition old, JobPosition update)
    {
        old.Section = update.Section;
        old.PositionName = update.PositionName;
    }
    public void Post(JobPosition jobPosition)
    {
        jobPosition.IdJobPosition = _id++;
        _jobs.Add(jobPosition);
    }
    public bool Delete(int id)
    {
        var job = GetById(id);
        if (job == null) { return false; }
        _jobs.Remove(job);
        return true;
    }
}
