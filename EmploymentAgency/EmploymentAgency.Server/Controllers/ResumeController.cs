using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using EmploymentAgency.Domain.Dto.ResumeDtos;
using AutoMapper;

namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResumeController(ServiseRepository repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получает список резюме из репозитория, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <returns>Возвращает HTTP-код ответа и коллекцию объектов ResumeDto</returns>
    [HttpGet]
    public async Task<IEnumerable<ResumeGetDto>> Get()
    {
        var resumes = await repository.Resumes.GetAllAsync();
        return mapper.Map<IEnumerable<ResumeGetDto>>(resumes);
    }

    /// <summary>
    /// Получает резюме из репозитория по Id, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Возвращает код HTTP-код ответа и найденое значение резюме по id</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ResumeDto>> Get(int id)
    {
        var resume = await repository.Resumes.GetByIdAsync(id);
        if (resume == null)
            return NotFound();

        return Ok(mapper.Map<ResumeDto>(resume));
    }

    /// <summary>
    /// Добавляет новое резюме в репозиторий в формате DTO
    /// </summary>
    /// <param name="resumeDto"></param>
    /// <returns>Возвращает HTTP-код  выполнения операции</returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ResumePostDto resumeDto)
    {
        //var message = "Резюме добавлено";
        //if (await repository.Applicants.GetByIdAsync(resumeDto.IdApplicant) == null)
        //    return NotFound("Кандидат на работу с таким ID не найден");     

        await repository.Resumes.PostAsync(mapper.Map<Resume>(resumeDto));
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
        if (await repository.Resumes.PutAsync(id, mapper.Map<Resume>(value)))
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
        if (await repository.Resumes.DeleteAsync(id))
            return Ok();
        return NotFound();
    }
}
