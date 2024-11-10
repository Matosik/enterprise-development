using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using EmploymentAgency.Server.DTO;
using AutoMapper;
namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResumeController(IRepository<Resume> repository, IMapper mapper) : ControllerBase
{
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
        var job = repository.GetById(id);
        if (job == null)
        {
            NotFound();
        }

        return Ok(mapper.Map<ResumeDto>(job));
    }

    /// <summary>
    /// Добавляет новое резюме в репозиторий в формате DTO
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Возвращает HTTP-код  выполнения операции</returns>
    [HttpPost]
    public IActionResult Post([FromBody] ResumeDto value)
    {
        repository.Post(mapper.Map<Resume>(value));

        return Ok();
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
