using EmploymentAgency.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Data;
using EmploymentAgency.Domain.Dto.ApplicantDtos;
using EmploymentAgency.Domain.Dto.JobPositionDtos;
using EmploymentAgency.Domain.Dto.EmployerDtos;

namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestController(ServiseRepository repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    ///Выводит сведения о всех соискателях, ищущих работу по заданной позиции. По дефолту ищет "backend developer C#"
    /// </summary>
    [HttpGet("applicants-by-position")]
    public async Task<ActionResult<IEnumerable<ApplicantGetDto>>> GetApplicantByPoitionAsync(string? positionName = "backend developer C#")
    {
        var jobs = await repository.Jobs.GetAllAsync();
        var resumes = await repository.Resumes.GetAllAsync();
        var applicants = await repository.Applicants.GetAllAsync();

        var query = from job in jobs
                    join resume in resumes on job.IdJobPosition equals resume.IdPosition
                    join applicant in applicants on resume.IdApplicant equals applicant.IdApplicant
                    where job.PositionName == positionName
                    orderby applicant.FirstName
                    select applicant;
        return Ok(mapper.Map<IEnumerable<ApplicantGetDto>>(query));
    }
    /// <summary>
    /// Выводит всех соискателей, оставивших заявки за заданный период. Или по дефолту с 2023.05.01 - 2023.7.30
    /// </summary>
    /// <returns></returns>
    [HttpGet("applicants-by-date")]
    public async Task<ActionResult<IEnumerable<ApplicantDto>>> GetApplicantByDateAsync(DateTime? startDate = null, DateTime? endDate = null)
    {
        startDate ??= new DateTime(2023, 5, 1);
        endDate ??= new DateTime(2023, 7, 30);
        var responses = await repository.Responses.GetAllAsync();
        var applicants = await repository.Applicants.GetAllAsync();

        var query = (from response in responses
                     join applicant in applicants on response.IdApplicant equals applicant.IdApplicant
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
    public async Task<ActionResult<IEnumerable<ApplicantDto>>> GetApplicantByVacancyIdAsunc(int? vacancyId = 1)
    {

        var vacansies = await repository.Vacancies.GetAllAsync();
        var jobs = await repository.Jobs.GetAllAsync();
        var resumes = await repository.Resumes.GetAllAsync();
        var applicants = await repository.Applicants.GetAllAsync();

        var query = from vacancy in vacansies
                    join job in jobs on vacancy.IdJobPosition equals job.IdJobPosition
                    join resume in resumes on job.IdJobPosition equals resume.IdPosition
                    join applicant in applicants on resume.IdApplicant equals applicant.IdApplicant
                    where resume.WantSalary <= vacancy.Salary && vacancy.IdVacancy == vacancyId
                    select applicant;
        return Ok(mapper.Map<IEnumerable<ApplicantDto>>(query));
    }
    /// <summary>
    /// Выводит информацию о кол-во заявок по каждому разделу и должности
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-response")]
    public async Task<ActionResult<IEnumerable<JobPositionWithCountResponseDto>>> GetCountResponseAsync()
    {
        var jobs = await repository.Jobs.GetAllAsync();
        var vacanciesGet = await repository.Vacancies.GetAllAsync();
        var responsesGet = await repository.Responses.GetAllAsync();

        var query = from job in jobs
                    join vacancy in vacanciesGet
                        on job.IdJobPosition equals vacancy.IdJobPosition into vacancies
                    from vacancy in vacancies.DefaultIfEmpty()
                    join response in responsesGet
                        on vacancy?.IdVacancy equals response.IdVacancy into responses
                    from response in responses.DefaultIfEmpty()
                    group response by job into grouped
                    select new JobPositionWithCountResponseDto
                    {
                        JobPosition = mapper.Map<JobPositionGetDto>(grouped.Key),
                        Count = grouped.Count(r => r != null) // Считаем только не-null Responses
                    };
        return Ok(query);
    }

    /// <summary>
    /// Вывод топ Работадателей по количеству вакансий
    /// </summary>
    /// <returns></returns> 
    [HttpGet("top-employers-by-vacancy")]
    public async  Task<ActionResult<IEnumerable<EmployerWithVacancyCountDto>>> GetTopEmployerByVacancyAsync(int top = 5)
    {

        var vacancies = await repository.Vacancies.GetAllAsync();
        var employers = await repository.Employers.GetAllAsync();

        var query = (from vacancy in vacancies
                     join employer in employers on vacancy.IdEmployer equals employer.IdEmployer
                     group employer by employer into g
                     orderby g.Count() descending
                     select new EmployerWithVacancyCountDto
                     {
                         Employer = mapper.Map<EmployerGetDto>(g.Key),
                         Count = g.Count()
                     })
             .Take(top);

        return Ok(mapper.Map<IEnumerable<EmployerWithVacancyCountDto>>(query));
    }
    /// <summary>
    /// Выводит информацию о работодателях, открывших заявки с максимальным уровнем зарплаты.
    /// </summary>
    /// <returns></returns>
    [HttpGet("min-salary-vacancy")]
    public async Task<ActionResult<IEnumerable<EmployerWithSalaryVacancyDto>>> GetEmployersByMaxSalaryAsync()
    {
        var vacancies = await repository.Vacancies.GetAllAsync();
        var employers = await repository.Employers.GetAllAsync();

        var maxSalary = vacancies.Max(x => x.Salary);
        var query = from vacancy in vacancies
                    join employer in employers on vacancy.IdEmployer equals employer.IdEmployer
                    where vacancy.Salary == maxSalary
                    orderby employer.IdEmployer
                    select new EmployerWithSalaryVacancyDto
                    {
                        Employerr = mapper.Map<EmployerGetDto>(employer),
                        Salary = maxSalary
                    };

        return Ok(mapper.Map<IEnumerable<EmployerWithSalaryVacancyDto>>(query));
    }
}
