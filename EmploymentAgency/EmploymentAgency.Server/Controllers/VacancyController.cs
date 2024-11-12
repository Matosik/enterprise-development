using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using EmploymentAgency.Domain.DTO;
using AutoMapper;
using static System.Reflection.Metadata.BlobBuilder;
namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VacancyController(IRepository<Vacancy> repository, IRepository<Employer> repositoryEmployer, IRepository<JobPosition> repositoryJob, IRepository<Response> repositoryResponse, IMapper mapper) : ControllerBase
{
    private readonly IRepository<Employer> _repositoryEmployer = repositoryEmployer;
    private readonly IRepository<JobPosition> _repositoryJob = repositoryJob;
    private readonly IRepository<Response> _repositoryResponse = repositoryResponse;

    /// <summary>
    /// Получает список вакансий из репозитория, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <returns>Возвращает HTTP-код ответа и коллекцию объектов VacancyDto</returns>
    [HttpGet]
    public ActionResult<IEnumerable<VacancyDto>> Get()
    {
        var repoDto = mapper.Map<IEnumerable<VacancyDto>>(repository.GetAll());
        return Ok(repoDto);
    }

    /// <summary>
    /// Получает вакансию из репозитория по Id, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Возвращает код HTTP-код ответа и найденое значение вакансии по id</returns>
    [HttpGet("{id}")]
    public ActionResult<VacancyDto> Get(int id)
    {
        var vacancy = repository.GetById(id);
        if (vacancy == null)
        {
            NotFound();
        }

        return Ok(mapper.Map<VacancyDto>(vacancy));
    }

    /// <summary>
    /// Добавляет новую вакансию в репозиторий в формате DTO
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Возвращает HTTP-код  выполнения операции</returns>
    [HttpPost]
    public IActionResult Post([FromBody] VacancyPostDto value)
    {
        string message = "Создание Вакансии прошло успешно";
        if (_repositoryEmployer.GetById(value.IdEmployer) == null)
        {
            return NotFound("Работодатель с таким ID не найден");
        };
        var jobs = _repositoryJob.GetAll();
        var cur = value.Job;
        JobPosition? job;

        job = jobs.FirstOrDefault(s => s.PositionName == cur.PositionName && s.Section == cur.Section);
        if (job == null)
        {
            job = _repositoryJob.Post(mapper.Map<JobPosition>(value.Job));
            message += "\nТакой рабочей позиции нет, но спецально для вас добавили";
        }
        var added = mapper.Map<Vacancy>(value);
        added.IdJobPosition = job.IdJobPosition;
        repository.Post(mapper.Map<Vacancy>(added));
        return Ok(message);
    }


    /// <summary>
    /// Обновляет существующую вакансию в репозитории на основе переданных данных в формате DTO
    /// </summary>
    /// <param name="id">Идентификатор вакансии для обновления</param>
    /// <param name="value">Объект VacancyPutDto с обновленными данными вакансии</param>
    /// <returns>Возвращает HTTP-код  выполнения операции </returns>    
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] VacancyPutDto value)
    {
        if (repository.Put(id, mapper.Map<Vacancy>(value)))
        {
            return Ok();
        }
        return NotFound();
    }

    /// <summary>
    /// Удаляет вакансию из репозитория по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор вакансии для удаления</param>
    /// <returns>Возвращает HTTP-код операции</returns>    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var responses = _repositoryResponse.GetAll();
        foreach (var response in responses)
        {
            if(response.IdVacancy == id)
            {
                _repositoryResponse.Delete(response);
            }
        }
        if (repository.Delete(id)) { return Ok(); }
        return NotFound();
    }
}
