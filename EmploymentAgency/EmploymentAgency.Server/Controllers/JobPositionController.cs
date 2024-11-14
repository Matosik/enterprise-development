using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using EmploymentAgency.Domain.DTO;
using AutoMapper;

namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobPositionController(ServiseRepository repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получает список рабочих позиций из репозитория, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <returns>Возвращает HTTP-код ответа и коллекцию объектов JobPosition</returns>
    [HttpGet]
    public ActionResult<IEnumerable<JobPositionDto>> Get()
    {
        var repoDto = mapper.Map<IEnumerable<JobPositionDto>>(repository.Jobs.GetAll());
        return Ok(repoDto);
    }

    /// <summary>
    /// Получает рабочую позицию из репозитория по Id, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Возвращает код HTTP-код ответа и найденое значение рабочая позиция по id</returns>
    [HttpGet("{id}")]
    public ActionResult<JobPositionDto> Get(int id)
    {
        var job = repository.Jobs.GetById(id);
        if (job == null)
           return NotFound();

        return Ok(mapper.Map<JobPositionDto>(job));
    }

    /// <summary>
    /// Добавляет новую рабочую позицию в репозиторий в формате DTO
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Возвращает HTTP-код  выполнения операции</returns>
    [HttpPost]
    public IActionResult Post([FromBody] JobPositionDto value)
    {
        repository.Jobs.Post(mapper.Map<JobPosition>(value));
        return Ok();
    }

    /// <summary>
    /// Обновляет существующую рабочую позицию в репозитории на основе переданных данных в формате DTO
    /// </summary>
    /// <param name="id">Идентификатор рабочей позиции для обновления</param>
    /// <param name="value">Объект JobPositionDto с обновленными данными рабочая позиция</param>
    /// <returns>Возвращает HTTP-код  выполнения операции </returns> 
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] JobPositionDto value)
    {
        if (repository.Jobs.Put(id, mapper.Map<JobPosition>(value)))
            return Ok();
        return NotFound();
    }

    /// <summary>
    /// Удаляет рабочую позицию из репозитория по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор рабочей позиции для удаления</param>
    /// <returns>Возвращает HTTP-код операции</returns> 
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var vacancyesToDelete = (from vacancy in repository.Vacancies.GetAll()
                                 where vacancy.IdEmployer == id
                                 select vacancy);

        var responsesToDelete = (from response in repository.Responses.GetAll()
                                 join vacancy in vacancyesToDelete on response.IdVacancy equals vacancy.IdVacancy
                                 select response);

        foreach (var response in responsesToDelete)
        {
            repository.Responses.Delete(response);
        }

        foreach (var vacancy in vacancyesToDelete)
        {
            repository.Vacancies.Delete(vacancy);
        }

        if (repository.Jobs.Delete(id)) 
            return Ok();
        return NotFound();
    }
}
