namespace EmploymentAgency.Test;
public class EmploymentAgencyTest
{
    private readonly EmploymentAgencyData _data = new EmploymentAgencyData();  
    /// <summary>
    /// 1.Вывести сведения о всех соискателях, ищущих работу по заданной позиции(JobPosition.PositionName), отсортированные по имени А-Я.
    /// </summary>
    [Fact]
    public void TestGetAllApplicantByPositionName()
    {
        List<int> expectedData = [3, 5, 2];
        var positionName = "backend developer C#";
        var query = (from job in _data.Jobs
                     join resume in _data.Resumes on job.IdJobPosition equals resume.IdPosition
                     join applicant in _data.Applicants on resume.IdApplicant equals applicant.IdApplicant
                     where job.PositionName == positionName
                     orderby applicant.FirstName
                     select applicant.IdApplicant)
                     .ToList();
        Assert.Equal(expectedData, query);
    }
    /// <summary>
    /// 1.1 Custom.Вывести сведения о всех соискателях, ищущих работу по заданному разделу(JobPosition.Section), отсортированные по имени Я-A.
    /// </summary>
    [Fact]
    public void TestGetAllApplicantBySection()
    {
        List<int> expectedData = [2, 1, 5, 3];
        var section = "IT";
        var query = (from job in _data.Jobs
                     join resume in _data.Resumes on job.IdJobPosition equals resume.IdPosition
                     join applicant in _data.Applicants on resume.IdApplicant equals applicant.IdApplicant
                     where job.Section == section
                     orderby applicant.FirstName descending
                     select applicant.IdApplicant)
                     .ToList();
        Assert.Equal(expectedData, query);
    }

    /// <summary>
    /// 2. Вывести всех соискателей, оставивших заявки за заданный период.
    /// </summary>
    [Fact]
    public void TestGetApplicantByResponsesWithinPeriod()
    {
        List<int> expectedData = [1, 2, 3, 4];
        var startDate = new DateTime(2023, 3, 1);
        var endDate = new DateTime(2023, 7, 30);
        var query = (from response in _data.Responses
                     join applicant in _data.Applicants on response.IdApplicant equals applicant.IdApplicant
                     where response.DateResponse >= startDate && response.DateResponse <= endDate
                     orderby applicant.IdApplicant
                     select applicant.IdApplicant)
                     .Distinct()
                     .ToList();

        Assert.Equal(expectedData, query);
    }

    /// <summary>
    /// 3. Вывести сведения о соискателях, соответствующих определенной заявке работодателя.
    /// </summary>
    [Fact]
    public void TestGetApplicantForSpecificVacancy()
    {
        List<int> expectedData = [1];
        var vacancyId = 1;
        var query = (from vacancy in _data.Vacancies
                     join job in _data.Jobs on vacancy.IdJobPosition equals job.IdJobPosition
                     join resume in _data.Resumes on job.IdJobPosition equals resume.IdPosition
                     join applicant in _data.Applicants on resume.IdApplicant equals applicant.IdApplicant
                     where resume.WantSalary <= vacancy.Salary && vacancy.IdVacancy == vacancyId
                     select applicant.IdApplicant)
                     .ToList();
        Assert.Equal(expectedData, query);
    }

    /// <summary>
    /// 4. Вывести информацию о количестве заявок по каждому разделу и должности.
    /// </summary>
    [Fact]
    public void TestGetVacancyCountByPosition()
    {
        var expectedData = new Dictionary<string, int>()
        {
            { "Специалист по цифровому маркетингу", 2},
            { "backend developer python", 2},
            { "backend developer C#", 1},
            { "Финансовый аналитик", 1 }
        };
        var query = (from response in _data.Responses
                     join vacancy in _data.Vacancies on response.IdVacancy equals vacancy.IdVacancy
                     join job in _data.Jobs on vacancy.IdJobPosition equals job.IdJobPosition
                     group response by new { job.PositionName } into g
                     select new
                     {
                         SectionPosition = g.Key.PositionName,
                         Count = g.Count()
                     })
                     .ToDictionary(x => x.SectionPosition, x => x.Count);
        Assert.Equal(expectedData, query);
    }
    /// <summary>
    /// 4.1 Вывести информацию о количестве заявок по каждому разделу и должности.
    /// </summary>
    [Fact]
    public void TestGetVacancyCountBySectionAndPosition()
    {
        var expectedData = new Dictionary<string, int>()
        {
            { "Рабочая позиция - Специалист по цифровому маркетингу", 2},
            { "Рабочая позиция - backend developer python", 2},
            { "Рабочая позиция - backend developer C#", 1},
            { "Рабочая позиция - Финансовый аналитик", 1 },
            { "Раздел - Маркетинг", 2},
            { "Раздел - IT", 3},
            { "Раздел - Финансы", 1 }
        };
        var queryPositionName = (from response in _data.Responses
                                 join vacancy in _data.Vacancies on response.IdVacancy equals vacancy.IdVacancy
                                 join job in _data.Jobs on vacancy.IdJobPosition equals job.IdJobPosition
                                 group response by new { job.PositionName } into g
                                 select new
                                 {
                                     Position = $"Рабочая позиция - {g.Key.PositionName}",
                                     Count = g.Count()
                                 })
                     .ToDictionary(x => x.Position, x => x.Count);
        var querySection = (from response in _data.Responses
                            join vacancy in _data.Vacancies on response.IdVacancy equals vacancy.IdVacancy
                            join job in _data.Jobs on vacancy.IdJobPosition equals job.IdJobPosition
                            group response by new { job.Section } into g
                            select new
                            {
                                SectionAns = $"Раздел - {g.Key.Section}",
                                Count = g.Count()
                            })
                            .ToDictionary(x => x.SectionAns, x => x.Count);

        var query = queryPositionName.Concat(querySection)
                                     .ToDictionary(x => x.Key, x => x.Value);
        Assert.Equal(expectedData, query);
    }
    /// <summary>
    /// 5. Вывести топ 5 работодателей по количеству заявок.
    /// </summary>
    [Fact]
    public void TestGetTop5EmployersByVacancyCount()
    {
        List<int> expectedData = [1, 2, 3, 4];
        var query = (from vacancy in _data.Vacancies
                     join employer in _data.Employers on vacancy.IdEmployer equals employer.IdEmployer
                     group vacancy by new { employer.IdEmployer, employer.Company } into g
                     orderby g.Count() descending
                     select g.Key.IdEmployer)
                     .Take(5)
                     .ToList();
        query.Sort();
        Assert.Equal(expectedData, query);
    }

    /// <summary>
    /// 6. Вывести информацию о работодателях, открывших заявки с максимальным уровнем зарплаты.
    /// </summary>
    [Fact]
    public void TestGetEmployersWithMaxSalaryVacancies()
    {
        List<int> expectedData = [2,3];
        var query = (from vacancy in _data.Vacancies
                     join employer in _data.Employers on vacancy.IdEmployer equals employer.IdEmployer
                     where vacancy.Salary == _data.Vacancies.Max(x => x.Salary)
                     orderby employer.IdEmployer
                     select employer.IdEmployer)
                     .ToList();
        Assert.Equal(expectedData, query);
    }
}