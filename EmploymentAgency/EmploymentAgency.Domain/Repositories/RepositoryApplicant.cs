﻿using EmploymentAgency.Domain.Models;

namespace EmploymentAgency.Domain.Repositories;

public class RepositoryApplicant : IRepository<Applicant>
{
    private int _id = 0;
    private readonly List<Applicant> _applicants = [];
    public IEnumerable<Applicant> GetAll() => _applicants;
    public Applicant? GetById(int id) => _applicants.Find(v => v.IdApplicant == id);
    public Applicant Post(Applicant applicant)
    {
        applicant.IdApplicant = _id++;
        _applicants.Add(applicant);
        return applicant;
    }
    public void Overwrite(ref Applicant old, Applicant update)
    {
        if (update.Birthday != DateOnly.MinValue)
        {
            old.Birthday = update.Birthday;
        }
        old.Number = update.Number;
        if (update.Registration != null)
        {
            old.Registration = update.Registration;
        }
        old.FirstName = update.FirstName;
        old.LastName = update.LastName;
    }
    public void Delete(Applicant applicant)
    {
        _applicants.Remove(applicant);
    }
    public bool Delete(int id)
    {
        var vacancy = GetById(id);
        if (vacancy == null) { return false; }
        _applicants.Remove(vacancy);
        return true;
    }
}
