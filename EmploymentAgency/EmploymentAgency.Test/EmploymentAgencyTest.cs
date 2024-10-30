namespace EmploymentAgency.Test;
public class EmploymentAgencyTest
{
    private EmploymentAgencyData data;
    public EmploymentAgencyTest()
    {
        data = new EmploymentAgencyData();
    }
    /// <summary>
    /// 1.Вывести сведения о всех соискателях, ищущих работу по заданной позиции, отсортированные по имени.
    /// </summary>
    [Fact]
    public void TestGetAllSlavesByJobPositionSortedByName()
    {
        int jobPositionId = 1;
        var applicants = data.Applicants
            .Where(a => data.Resumes.Any(r => r.IdApplicant == a.IdApplicant && r.IdPosition == jobPositionId))
            .OrderBy(a => a.FirstName)
            .ToList();

        Assert.NotEmpty(applicants);
        Assert.All(applicants, a => Assert.True(data.Resumes.Any(r => r.IdApplicant == a.IdApplicant && r.IdPosition == jobPositionId)));
    }

    /// <summary>
    /// 2. Вывести всех соискателей, оставивших заявки за заданный период.
    /// </summary>
    [Fact]
    public void TestGetSlavesByResponsesWithinPeriod()
    {
        DateTime startDate = new DateTime(2023, 1, 1) ;
        DateTime endDate = new DateTime(2023, 12, 31);
        var applicants = data.Applicants
            .Where(a => data.Responses.Any(r => r.IdApplicant == a.IdApplicant && r.DateResponse >= startDate && r.DateResponse <= endDate))
            .ToList();

        Assert.NotEmpty(applicants);
        Assert.All(applicants, a => Assert.True(data.Responses.Any(r => r.IdApplicant == a.IdApplicant && r.DateResponse >= startDate && r.DateResponse <= endDate)));
    }

    /// <summary>
    /// 3. Вывести сведения о соискателях, соответствующих определенной заявке работодателя.
    /// </summary>
    [Fact]
    public void TestGetSlavesForSpecificVacancy()
    {
        int vacancyId = 2;
        var vacancy = data.Vacancies.FirstOrDefault(v => v.IdVacancy == vacancyId);
        var matchingApplicants = data.Applicants
            .Where(a => data.Resumes.Any(r => r.IdApplicant == a.IdApplicant && r.IdPosition == vacancy.IdJobPosition && r.WantSalary <= vacancy.Salary))
            .ToList();

        Assert.NotNull(vacancy);
        Assert.NotEmpty(matchingApplicants);
        Assert.All(matchingApplicants, a => Assert.True(data.Resumes.Any(r => r.IdApplicant == a.IdApplicant && r.IdPosition == vacancy.IdJobPosition && r.WantSalary <= vacancy.Salary)));
    }

    /// <summary>
    /// 4. Вывести информацию о количестве заявок по каждому разделу и должности.
    /// </summary>
    [Fact]
    public void TestGetVacancyCountBySectionAndPosition()
    {
        var vacancyCounts = data.Vacancies
            .GroupBy(v => new { v.IdJobPosition, Section = data.Jobs.First(j => j.IdJobPosition == v.IdJobPosition).Section })
            .Select(g => new
            {
                Section = g.Key.Section,
                PositionName = data.Jobs.First(j => j.IdJobPosition == g.Key.IdJobPosition).PositionName,
                Count = g.Count()
            })
            .ToList();

        Assert.NotEmpty(vacancyCounts);
        Assert.All(vacancyCounts, vc => Assert.True(vc.Count > 0));
    }

    /// <summary>
    /// 5. Вывести топ 5 работодателей по количеству заявок.
    /// </summary>
    [Fact]
    public void TestGetTop5EmployersByVacancyCount()
    {
        var topEmployers = data.Employers
            .Select(e => new
            {
                Employer = e,
                VacancyCount = data.Vacancies.Count(v => v.IdEmployer == e.IdEmployer)
            })
            .OrderByDescending(e => e.VacancyCount)
            .Take(5)
            .ToList();

        Assert.True(topEmployers.Count <= 5);
        Assert.All(topEmployers, te => Assert.True(te.VacancyCount >= 0));
    }

    /// <summary>
    /// 6. Вывести информацию о работодателях, открывших заявки с максимальным уровнем зарплаты.
    /// </summary>
    [Fact]
    public void TestGetEmployersWithMaxSalaryVacancies()
    {
        var maxSalary = data.Vacancies.Max(v => v.Salary);
        var employersWithMaxSalaryVacancies = data.Employers
            .Where(e => data.Vacancies.Any(v => v.IdEmployer == e.IdEmployer && v.Salary == maxSalary))
            .ToList();

        Assert.NotEmpty(employersWithMaxSalaryVacancies);
        Assert.All(employersWithMaxSalaryVacancies, e => Assert.True(data.Vacancies.Any(v => v.IdEmployer == e.IdEmployer && v.Salary == maxSalary)));
    }
}