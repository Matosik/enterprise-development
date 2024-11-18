using EmploymentAgency.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Data;
using EmploymentAgency.Domain.DTO.ApplicantD;
using EmploymentAgency.Domain.DTO.JobPositionD;
using EmploymentAgency.Domain.DTO.EmployerD;
using EmploymentAgency.Domain.Models;

namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestController(ServiseRepository repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    ///Выводит сведения о всех соискателях, ищущих работу по заданной позиции. По дефолту ищет "backend developer C#"
    /// </summary>
    [HttpGet("applicants-by-position")]
    public ActionResult<IEnumerable<ApplicantDto>> GetApplicantByPoition(string? positionName = null)
    {
        positionName ??= "backend developer C#";
        var query = from job in repository.Jobs.GetAll()
                     join resume in repository.Resumes.GetAll() on job.IdJobPosition equals resume.IdPosition
                     join applicant in repository.Applicants.GetAll() on resume.IdApplicant equals applicant.IdApplicant
                     where job.PositionName == positionName
                     orderby applicant.FirstName
                     select applicant;
        return Ok(mapper.Map<IEnumerable<ApplicantDto>>(query));
    }
    /// <summary>
    /// Выводит всех соискателей, оставивших заявки за заданный период. Или по дефолту с 2023.05.01 - 2023.7.30
    /// </summary>
    /// <returns></returns>
    [HttpGet("applicants-by-date")]
    public ActionResult<IEnumerable<ApplicantDto>> GetApplicantByDate(DateTime? startDate = null, DateTime? endDate = null)
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
    public ActionResult<IEnumerable<ApplicantDto>> GetApplicantByVacancyId(int? vacancyId = 1)
    {
        var query = from vacancy in repository.Vacancies.GetAll()
                     join job in repository.Jobs.GetAll() on vacancy.IdJobPosition equals job.IdJobPosition
                     join resume in repository.Resumes.GetAll() on job.IdJobPosition equals resume.IdPosition
                     join applicant in repository.Applicants.GetAll() on resume.IdApplicant equals applicant.IdApplicant
                     where resume.WantSalary <= vacancy.Salary && vacancy.IdVacancy == vacancyId
                     select applicant;
        return Ok(mapper.Map<IEnumerable<ApplicantDto>>(query));
    }
    /// <summary>
    /// Выводит информацию о кол-во заявок по каждому разделу и должности
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-response")]
    public IEnumerable<JobPositionWithCountResponseDto> GetCountResponse()
    {
        var query = from job in repository.Jobs.GetAll() 
                    join vacancy in repository.Vacancies.GetAll()
                        on job.IdJobPosition equals vacancy.IdJobPosition into vacancies
                    from vacancy in vacancies.DefaultIfEmpty() 
                    join response in repository.Responses.GetAll()
                        on vacancy?.IdVacancy equals response.IdVacancy into responses
                    from response in responses.DefaultIfEmpty() 
                    group response by job into grouped 
                    select new JobPositionWithCountResponseDto
                    {
                        JobPosition = mapper.Map<JobPositionGetDto>(grouped.Key),
                        Count = grouped.Count(r => r != null) // Считаем только не-null Responses
                    };
        return query;
    }
    
    /// <summary>
    /// Вывод топ Работадателей по количеству вакансий
    /// </summary>
    /// <returns></returns>
    [HttpGet("top-employers-by-vacancy")]
    public IEnumerable<EmployerWithVacancyCountDto> GetTopEmployerByVacancy(int Top = 5)
    {
        var query = (from vacancy in repository.Vacancies.GetAll()
                     join employer in repository.Employers.GetAll() on vacancy.IdEmployer equals employer.IdEmployer
                     group employer by employer into g
                     orderby g.Count() descending
                     select new EmployerWithVacancyCountDto
                     {
                         Employer = mapper.Map<EmployerGetDto>(g.Key),
                         Count = g.Count()
                     })
             .Take(Top);

        return mapper.Map<IEnumerable<EmployerWithVacancyCountDto>>(query);
    }
    /// <summary>
    /// Выводит информацию о работодателях, открывших заявки с максимальным уровнем зарплаты.
    /// </summary>
    /// <returns></returns>
    [HttpGet("min-salary-vacancy")]
    public IEnumerable<EmployerWithSalaryVacancyDto> GetEmployersByMaxSalary()
    {
        var maxSalary = repository.Vacancies.GetAll().Max(x => x.Salary);
        var query = from vacancy in repository.Vacancies.GetAll()
                     join employer in repository.Employers.GetAll() on vacancy.IdEmployer equals employer.IdEmployer
                     where vacancy.Salary == maxSalary
                     orderby employer.IdEmployer
                     select new EmployerWithSalaryVacancyDto
                     {
                         Employerr = mapper.Map<EmployerGetDto>(employer),
                         Salary = maxSalary
                     };

        return mapper.Map<IEnumerable<EmployerWithSalaryVacancyDto>>(query);
    }
}
