using EmploymentAgency.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentAgency.Domain.Repositories;

public class RepositoryVacancy : IRepository<Vacancy>
{
    private readonly List<Vacancy> _vacancies = [];

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Vacancy> Gets()
    {
        throw new NotImplementedException();
    }

    public Vacancy? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Post(Vacancy entity)
    {
        throw new NotImplementedException();
    }

    public bool Put(int id, Vacancy entity)
    {
        throw new NotImplementedException();
    }
}
