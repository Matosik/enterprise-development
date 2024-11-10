using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentAgency.Domain.Repositories;


internal interface IRepository<T>
{
    public IEnumerable<T> Gets();
    public T? GetById(int id);
    public void Post(T entity);
    public bool Put(int id,T entity);
    public bool Delete(int id);
}
