using EmploymentAgency.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentAgency.Domain.Repositories;

internal class RepositoryJobPosition : IRepository<JobPosition>
{
    private readonly List<JobPosition> _jobs = [];

    public JobPosition? GetById(int id) => _jobs.Find(j=> j.IdJobPosition == id);

    public IEnumerable<JobPosition> Gets() => _jobs;

    public void Overwrite(ref JobPosition old, JobPosition update)
    {
        old.Section = update.Section;
        old.PositionName = update.PositionName;
    }
    public void Post(JobPosition jobPosition)
    {
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
