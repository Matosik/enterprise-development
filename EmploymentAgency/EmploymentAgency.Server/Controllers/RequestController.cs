using EmploymentAgency.Domain.DTO;
using EmploymentAgency.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Data;

namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestController(ServiseRepository repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    ///Выводит сведения о всех соискателях, ищущих работу по заданной позиции. По дефолту ищет "backend developer C#"
    /// </summary>
    [HttpGet("applicants-by-position")]
    public ActionResult<IEnumerable<ApplicantDto>> Get1(string? positionName = null)
    {
        positionName ??= "backend developer C#";
        var query = (from job in repository.Jobs.GetAll()
                     join resume in repository.Resumes.GetAll() on job.IdJobPosition equals resume.IdPosition
                     join applicant in repository.Applicants.GetAll() on resume.IdApplicant equals applicant.IdApplicant
                     where job.PositionName == positionName
                     orderby applicant.FirstName
                     select applicant);
        var q = mapper.Map<IEnumerable<ApplicantDto>>(query);
        return Ok(q);
    }
    /// <summary>
    /// Выводит всех соискателей, оставивших заявки за заданный период. Или по дефолту с 2023.05.01 - 2023.7.30
    /// </summary>
    /// <returns></returns>
    [HttpGet("applicants-by-date")]
    public ActionResult<IEnumerable<ApplicantDto>> Get2(DateTime? startDate = null, DateTime? endDate = null)
    {
        startDate ??= new DateTime(2023, 5, 1);
        endDate ??= new DateTime(2023, 7, 30);
        var query = (from response in repository.Responses.GetAll()
                     join applicant in repository.Applicants.GetAll() on response.IdApplicant equals applicant.IdApplicant
                     where response.DateResponse >= startDate && response.DateResponse <= endDate
                     orderby applicant.IdApplicant
                     select applicant)
                     .Distinct();
        return Ok(mapper.Map<IEnumerable<ApplicantDto>>(query));
    }
    /// <summary>
    /// Вывести сведения о соискателях, соответствующих определенной заявке работодателя
    /// </summary>
    /// <param name="vacancyId"></param>
    /// <returns></returns>
    [HttpGet("applicants-by-vacancy")]
    public ActionResult<IEnumerable<ApplicantDto>> Get3(int? vacancyId = 1)
    {
        var query = (from vacancy in repository.Vacancies.GetAll()
                     join job in repository.Jobs.GetAll() on vacancy.IdJobPosition equals job.IdJobPosition
                     join resume in repository.Resumes.GetAll() on job.IdJobPosition equals resume.IdPosition
                     join applicant in repository.Applicants.GetAll() on resume.IdApplicant equals applicant.IdApplicant
                     where resume.WantSalary <= vacancy.Salary && vacancy.IdVacancy == vacancyId
                     select applicant);
        return Ok(mapper.Map<IEnumerable<ApplicantDto>>(query));
    }
    /// <summary>
    /// Выводит информацию о кол-во заявок по каждому разделу и должности
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-response")]
    public Dictionary<string, int> Get4()
    {
        var query = (from response in repository.Responses.GetAll()
                     join vacancy in repository.Vacancies.GetAll() on response.IdVacancy equals vacancy.IdVacancy
                     join job in repository.Jobs.GetAll() on vacancy.IdJobPosition equals job.IdJobPosition
                     group response by new { job.PositionName } into g
                     select new
                     {
                         SectionPosition = g.Key.PositionName,
                         Count = g.Count()
                     })
                     .ToDictionary(x => x.SectionPosition, x => x.Count);
        return query;
    }
    /// <summary>
    /// Выводит информацию о количестве заявок по каждому разделу и должности
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-response-All")]
    public Dictionary<string, int> Get4p1()
    {
        var queryPositionName = (from response in repository.Responses.GetAll()
                                 join vacancy in repository.Vacancies.GetAll() on response.IdVacancy equals vacancy.IdVacancy
                                 join job in repository.Jobs.GetAll() on vacancy.IdJobPosition equals job.IdJobPosition
                                 group response by new { job.PositionName } into g
                                 select new
                                 {
                                     Position = $"Рабочая позиция - {g.Key.PositionName}",
                                     Count = g.Count()
                                 })
                     .ToDictionary(x => x.Position, x => x.Count);
        var querySection = (from response in repository.Responses.GetAll()
                            join vacancy in repository.Vacancies.GetAll() on response.IdVacancy equals vacancy.IdVacancy
                            join job in repository.Jobs.GetAll() on vacancy.IdJobPosition equals job.IdJobPosition
                            group response by new { job.Section } into g
                            select new
                            {
                                SectionAns = $"Раздел - {g.Key.Section}",
                                Count = g.Count()
                            })
                            .ToDictionary(x => x.SectionAns, x => x.Count);

        var query = queryPositionName.Concat(querySection)
                                     .ToDictionary(x => x.Key, x => x.Value);
        return query;
    }
    /// <summary>
    /// Вывод топ 5 Работадателей по количеству вакансий
    /// </summary>
    /// <returns></returns>
    [HttpGet("top-five-employers")]
    public IEnumerable<EmployerDto> Get5()
    {
        var query = (from vacancy in repository.Vacancies.GetAll()
                     join employer in repository.Employers.GetAll() on vacancy.IdEmployer equals employer.IdEmployer
                     group employer by employer into g
                     orderby g.Count() descending
                     select g.Key)
             .Take(5);

        return mapper.Map<IEnumerable<EmployerDto>>(query);
    }
    /// <summary>
    /// Выводит информацию о работодателях, открывших заявки с максимальным уровнем зарплаты.
    /// </summary>
    /// <returns></returns>
    [HttpGet("min-salary-vacancy")]
    public IEnumerable<EmployerDto> Get6()
    {
        var query = (from vacancy in repository.Vacancies.GetAll()
                     join employer in repository.Employers.GetAll() on vacancy.IdEmployer equals employer.IdEmployer
                     where vacancy.Salary == repository.Vacancies.GetAll().Max(x => x.Salary)
                     orderby employer.IdEmployer
                     select employer);
        return mapper.Map<IEnumerable<EmployerDto>>(query);
    }
}
