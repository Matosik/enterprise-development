﻿using EmploymentAgency.Class;

namespace EmploymentAgency.Test;
public class EmploymentAgencyTest
{
    /// <summary>
    /// 1.Вывести сведения о всех соискателях, ищущих работу по заданной 
    /// </summary>
    [Fact]
    public void TestGetAllSlavesByJobPositionSortedByName()
    {

        var jobPosition = new JobPosition { IdJobPosition = 1, Section = "IT", PositionName = "Программист" };
        var slaves = new List<Applicant>
        {
            new Applicant { IdApplicant = 1, LastName = "Иванов", FirstName = "Иван", Age = 30, Resumes = new List<Resume> { new Resume { Position = jobPosition } } },
            new Applicant { IdApplicant = 2, LastName = "Петров", FirstName = "Петр", Age = 25, Resumes = new List<Resume> { new Resume { Position = jobPosition } } },
            new Applicant { IdApplicant = 3, LastName = "Сидоров", FirstName = "Сидор", Age = 35, Resumes = new List<Resume> { new Resume { Position = new JobPosition { Id = 2, Section = "Финансы", PositionName = "Бухгалтер" } } } },
            new Applicant { IdApplicant = 3, LastName = "Сидоров", FirstName = "Сидор", Age = 35, Resumes = new List<Resume> { new Resume { Position = new JobPosition { Id = 2, Section = "Финансы", PositionName = "Бухгалтер" } } } }
        };
        var result = slaves
            .Where(s => s.Resumes.Any(r => r.Position.PositionName == "Программист"))
            .OrderBy(s => s.FullName)
            .ToList();

        Assert.Equal(2, result.Count);
        Assert.Equal("Иванов Иван", result[0].FullName);
        Assert.Equal("Петров Петр", result[1].FullName);
    }
    /// <summary>
    /// 2. Вывести всех соискателей, оставивших заявки за заданный период.
    /// </summary>
    [Fact]
    public void Test_GetSlavesByResponsesWithinPeriod()
    {
        var startDate = new DateTime(2023, 1, 1);
        var endDate = new DateTime(2023, 12, 31);

        var slaves = new List<Applicant>
        {
            new Applicant { Id = 1, FullName = "Иванов Иван", Responses = new List<Response> { new Response { Date = new DateTime(2023, 5, 1) } } },
            new Applicant { Id = 2, FullName = "Петров Петр", Responses = new List<Response> { new Response { Date = new DateTime(2022, 10, 1) } } },
            new Applicant { Id = 3, FullName = "Сидоров Сидор", Responses = new List<Response> { new Response { Date = new DateTime(2023, 3, 15) } } }
        };

        var result = slaves
            .Where(s => s.Responses.Any(r => r.Date >= startDate && r.Date <= endDate))
            .ToList();


        Assert.Equal(2, result.Count);
        Assert.Contains(result, s => s.FullName == "Иванов Иван");
        Assert.Contains(result, s => s.FullName == "Сидоров Сидор");
    }
    /// <summary>
    /// 3. Вывести сведения о соискателях, соответствующих определенной заявке работодателя.
    /// </summary>
    [Fact]
    public void TestGetSlavesForSpecificVacancy()
    {
        var vacancy = new Vacancy
        {
            Id = 1,
            NameVacancy = "Программист",
            Job = new JobPosition { Id = 1, Section = "IT", PositionName = "Программист" },
            MinAge = 25,
            MaxAge = 35,
            Salary = 60000
        };

        var slaves = new List<Applicant>
        {
            new Applicant { Id = 1, FullName = "Иванов Иван", Age = 30, Resumes = new List<Resume> { new Resume { Position = vacancy.Job, WantSalary = 55000 } } },
            new Applicant { Id = 2, FullName = "Петров Петр", Age = 25, Resumes = new List<Resume> { new Resume { Position = vacancy.Job, WantSalary = 70000 } } },
            new Applicant { Id = 3, FullName = "Сидоров Сидор", Age = 40, Resumes = new List<Resume> { new Resume { Position = new JobPosition { Id = 2, Section = "Финансы", PositionName = "Бухгалтер" } } } }
        };

        var result = slaves
            .Where(s => s.Age >= vacancy.MinAge && s.Age <= vacancy.MaxAge &&
                        s.Resumes.Any(r => r.Position.PositionName == vacancy.Job.PositionName && r.WantSalary <= vacancy.Salary))
            .ToList();

        Assert.Single(result);
        Assert.Equal("Иванов Иван", result[0].FullName);
    }
    /// <summary>
    ///4. Вывести информацию о количестве заявок по каждому разделу и должности
    /// </summary>
    [Fact]
    public void Test_GetVacancyCountBySectionAndPosition()
    {
        var vacancies = new List<Vacancy>
        {
            new Vacancy { Id = 1, NameVacancy = "Программист", Job = new JobPosition { Id = 1, Section = "IT", PositionName = "Программист" } },
            new Vacancy { Id = 2, NameVacancy = "Дизайнер", Job = new JobPosition { Id = 1, Section = "IT", PositionName = "Дизайнер" } },
            new Vacancy { Id = 3, NameVacancy = "Бухгалтер", Job = new JobPosition { Id = 2, Section = "Финансы", PositionName = "Бухгалтер" } }
        };

        var result = vacancies
            .GroupBy(v => new { v.Job.Section, v.Job.PositionName })
            .Select(g => new { Section = g.Key.Section, PositionName = g.Key.PositionName, Count = g.Count() })
            .ToList();

        Assert.Equal(3, result.Count);
        Assert.Contains(result, r => r.Section == "IT" && r.PositionName == "Программист" && r.Count == 1);
        Assert.Contains(result, r => r.Section == "Финансы" && r.PositionName == "Бухгалтер" && r.Count == 1);
    }

    /// <summary>
    /// 5.Вывести топ 5 работодателей по количеству заявок
    /// </summary>
    [Fact]
    public void Test_GetTop5EmployersByVacancyCount()
    {
        var employers = new List<Employer>
        {
            new Employer { Id = 1, Company = "Компания A", Offers = new List<Vacancy> { new Vacancy(), new Vacancy() } },
            new Employer { Id = 2, Company = "Компания B", Offers = new List<Vacancy> { new Vacancy(), new Vacancy(), new Vacancy() } },
            new Employer { Id = 3, Company = "Компания C", Offers = new List<Vacancy> { new Vacancy() } },
            new Employer { Id = 4, Company = "Компания D", Offers = new List<Vacancy> { new Vacancy(), new Vacancy(), new Vacancy(), new Vacancy() } },
            new Employer { Id = 5, Company = "Компания E", Offers = new List<Vacancy> { new Vacancy(), new Vacancy() } },
            new Employer { Id = 6, Company = "Компания F", Offers = new List<Vacancy> { new Vacancy(), new Vacancy(), new Vacancy() } }
        };


        var result = employers
            .OrderByDescending(e => e.Offers.Count)
            .Take(5)
            .Select(e => new { e.Company, VacancyCount = e.Offers.Count })
            .ToList();

        Assert.Equal(5, result.Count);
        Assert.Equal("Компания D", result[0].Company);
        Assert.Equal(4, result[0].VacancyCount);
        Assert.Equal("Компания B", result[1].Company);
        Assert.Equal(3, result[1].VacancyCount);
    }
    /// <summary>
    /// 6.Вывести информацию о работодателях, открывших заявки с максимальным уровнем зарплаты.
    /// </summary>
    [Fact]
    public void Test_GetEmployersWithMaxSalaryVacancies()
    {

        var employers = new List<Employer>
        {
            new Employer { Id = 1, Company = "Компания A", Offers = new List<Vacancy> { new Vacancy { Salary = 50000 }, new Vacancy { Salary = 70000 } } },
            new Employer { Id = 2, Company = "Компания B", Offers = new List<Vacancy> { new Vacancy { Salary = 90000 }, new Vacancy { Salary = 80000 } } },
            new Employer { Id = 3, Company = "Компания C", Offers = new List<Vacancy> { new Vacancy { Salary = 90000 } } }
        };

        var maxSalary = employers
            .SelectMany(e => e.Offers)
            .Max(v => v.Salary);

        var result = employers
            .Where(e => e.Offers.Any(v => v.Salary == maxSalary))
            .Select(e => new { e.Company, MaxSalary = maxSalary })
            .ToList();

        // 3. Проверка результатов
        Assert.Equal(2, result.Count);
        Assert.Contains(result, e => e.Company == "Компания B");
        Assert.Contains(result, e => e.Company == "Компания C");
        Assert.All(result, e => Assert.Equal(90000u, e.MaxSalary));
    }

}