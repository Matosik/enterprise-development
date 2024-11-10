using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using EmploymentAgency.Server.DTO;
using AutoMapper;
namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VacancyController(IRepository<Vacancy> repository, IMapper mapper) : ControllerBase
{
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
        var job = repository.GetById(id);
        if (job == null)
        {
            NotFound();
        }

        return Ok(mapper.Map<VacancyDto>(job));
    }

    /// <summary>
    /// Добавляет новую вакансию в репозиторий в формате DTO
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Возвращает HTTP-код  выполнения операции</returns>
    [HttpPost]
    public IActionResult Post([FromBody] VacancyDto value)
    {
        repository.Post(mapper.Map<Vacancy>(value));

        return Ok();
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
        if (repository.Delete(id)) { return Ok(); }
        return NotFound();
    }
}
