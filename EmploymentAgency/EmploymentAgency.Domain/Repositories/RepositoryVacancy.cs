﻿using EmploymentAgency.Domain.Models;
namespace EmploymentAgency.Domain.Repositories;
public class RepositoryVacancy : IRepository<Vacancy>
{
    private int _id = 0;
    private readonly List<Vacancy> _vacancies = [];
    public IEnumerable<Vacancy> GetAll() => _vacancies;
    public Vacancy? GetById(int id) => _vacancies.Find(v => v.IdVacancy == id);
    public void Post(Vacancy vacancy)
    {
        vacancy.IdVacancy = _id++;
        _vacancies.Add(vacancy);
    }
    public void Overwrite(ref Vacancy old, Vacancy update)
    {
        old.DateVacancy = update.DateVacancy;
        old.NameVacancy = update.NameVacancy;
        old.Salary = update.Salary;
        old.Summary = update.Summary;
        old.IdEmployer = update.IdEmployer;
        old.IdJobPosition = update.IdJobPosition;
        old.IsActive = update.IsActive;
        old.Experience = update.Experience;
    }
    public bool Delete(int id)
    {
        var vacancy = GetById(id);
        if (vacancy == null) { return false; }
        _vacancies.Remove(vacancy);
        return true;
    }
}
