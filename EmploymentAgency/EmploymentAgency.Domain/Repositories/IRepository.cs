﻿using System;
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
    public void Overwrite(ref T old, T update);
    public bool Put(int id, T entity) {
        var oldEntity = GetById(id);
        if(oldEntity == null) { return false; }

        Overwrite(ref oldEntity, entity);
        return true;
    }
    public bool Delete(int id);
}
