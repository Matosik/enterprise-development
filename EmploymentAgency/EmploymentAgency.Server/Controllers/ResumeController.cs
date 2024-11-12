using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using EmploymentAgency.Domain.DTO;
using AutoMapper;
namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResumeController(IRepository<Resume> repository, IRepository<JobPosition> repositoryJob, IRepository<Applicant> repositoryApplicant, IMapper mapper) : ControllerBase
{
    private readonly IRepository<Applicant> _repositoryApplicant = repositoryApplicant;
    private readonly IRepository<JobPosition> _repositoryJob = repositoryJob;
    /// <summary>
    /// Получает список резюме из репозитория, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <returns>Возвращает HTTP-код ответа и коллекцию объектов ResumeDto</returns>
    [HttpGet]
    public ActionResult<IEnumerable<ResumeDto>> Get()
    {
        var repoDto = mapper.Map<IEnumerable<ResumeDto>>(repository.GetAll());
        return Ok(repoDto);
    }

    /// <summary>
    /// Получает резюме из репозитория по Id, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Возвращает код HTTP-код ответа и найденое значение резюме по id</returns>
    [HttpGet("{id}")]
    public ActionResult<ResumeDto> Get(int id)
    {
        var resume = repository.GetById(id);
        if (resume == null)
        {
            NotFound();
        }

        return Ok(mapper.Map<ResumeDto>(resume));
    }

    /// <summary>
    /// Добавляет новое резюме в репозиторий в формате DTO
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Возвращает HTTP-код  выполнения операции</returns>
    [HttpPost]
    public IActionResult Post([FromBody] ResumePostDto value)
    {
        var message = "Резюме добавлено";
        if (_repositoryApplicant.GetById(value.IdApplicant) == null)
        {
            return NotFound("Кандидат на работу с таким ID не найден");
        };
        var jobs = _repositoryJob.GetAll();
        var cur = value.Job;
        JobPosition? job;
        job = jobs.FirstOrDefault(s => s.PositionName == cur.PositionName && s.Section == cur.Section);
        
        repository.Post(mapper.Map<Resume>(value));
        if(job == null)
        {
            job = _repositoryJob.Post(mapper.Map<JobPosition>(value.Job));
            message += "Похоже на нашей площадке еще нет такой профессии. Но специально для вас мы добавили";
        }
        var added = mapper.Map<Resume>(value);
        repository.Post(added);
        return Ok(message);
    }

    /// <summary>
    /// Обновляет существующую резюме в репозитории на основе переданных данных в формате DTO
    /// </summary>
    /// <param name="id">Идентификатор резюме для обновления</param>
    /// <param name="value">Объект ResumePutDto с обновленными данными резюме</param>
    /// <returns>Возвращает HTTP-код  выполнения операции </returns>   
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ResumePutDto value)
    {
        if (repository.Put(id, mapper.Map<Resume>(value)))
        {
            return Ok();
        }
        return NotFound();
    }

    /// <summary>
    /// Удаляет резюме из репозитория по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор резюме для удаления</param>
    /// <returns>Возвращает HTTP-код операции</returns> 
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (repository.Delete(id)) { return Ok(); }
        return NotFound();
    }
}
