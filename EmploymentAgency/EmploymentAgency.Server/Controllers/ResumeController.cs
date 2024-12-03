using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using EmploymentAgency.Domain.Dto.ResumeDtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResumeController(IRepository<Resume> repository, IRepository<JobPosition> repositoryJob, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получает список резюме из репозитория, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <returns>Возвращает HTTP-код ответа и коллекцию объектов ResumeDto</returns>
    [HttpGet]
    public async Task<IEnumerable<ResumeGetDto>> Get()
    {
        var resumes = await repository.GetAllAsync();
        return mapper.Map<IEnumerable<ResumeGetDto>>(resumes);
    }

    /// <summary>
    /// Получает резюме из репозитория по Id, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <param name="id">Id резюме данные, которого мы хотим получить</param>
    /// <returns>Возвращает код HTTP-код ответа и найденое значение резюме по id</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ResumeDto>> Get(int id)
    {
        var resume = await repository.GetByIdAsync(id);
        if (resume == null)
            return NotFound();

        return Ok(mapper.Map<ResumeDto>(resume));
    }

    /// <summary>
    /// Добавляет новое резюме в репозиторий в формате DTO
    /// </summary>
    /// <param name="resumeDto"></param>
    /// <param name="id">Id соискателя который создает резюме</param>
    /// <returns>Возвращает HTTP-код  выполнения операции</returns>
    [HttpPost("{id}")]
    public async Task<IActionResult> Post(int id, [FromBody] ResumePostDto resumeDto)
    {
        var jobs = await repositoryJob.GetAllAsync();
        var job = jobs.FirstOrDefault(j => j.Section == resumeDto.Job.Section && j.PositionName == resumeDto.Job.PositionName);
        if (job == null)
            return NotFound("Такой вакансии не найдено, можете создать свою рабочую поизицию");

        var added = mapper.Map<Resume>(resumeDto);
        added.IdApplicant = id;
        added.IdPosition = job.IdJobPosition;
        try
        {
            await repository.PostAsync(added);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
        return Ok();
    }

    /// <summary>
    /// Обновляет существующую резюме в репозитории на основе переданных данных в формате DTO
    /// </summary>
    /// <param name="id">Идентификатор резюме для обновления</param>
    /// <param name="value">Объект ResumePutDto с обновленными данными резюме</param>
    /// <returns>Возвращает HTTP-код  выполнения операции </returns>   
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ResumePutDto value)
    {
        if (await repository.PutAsync(id, mapper.Map<Resume>(value)))
            return Ok();
        return NotFound();
    }

    /// <summary>
    /// Удаляет резюме из репозитория по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор резюме для удаления</param>
    /// <returns>Возвращает HTTP-код операции</returns> 
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (await repository.DeleteAsync(id))
            return Ok();
        return NotFound();
    }
}
