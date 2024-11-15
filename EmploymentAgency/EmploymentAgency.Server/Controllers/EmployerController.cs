using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using AutoMapper;
using EmploymentAgency.Domain.DTO.EmployerD;

namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployerController(ServiseRepository repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получает список Работодателей из репозитория, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <returns>Возвращает HTTP-код ответа и коллекцию объектов EmployerDto</returns>
    [HttpGet]
    public ActionResult<IEnumerable<EmployerGetDto>> Get()
    {
        var repoDto = mapper.Map<IEnumerable<EmployerGetDto>>(repository.Employers.GetAll());
        return Ok(repoDto);
    }

    /// <summary>
    /// Получает работадателя из репозитория по Id, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Возвращает код HTTP-код ответа и найденое значение работадатель по id</returns>
    [HttpGet("{id}")]
    public ActionResult<EmployerDto> Get(int id)
    {
        var employer = repository.Employers.GetById(id);
        if (employer == null)
            return NotFound();

        return Ok(mapper.Map<EmployerDto>(employer));
    }

    /// <summary>
    /// Добавляет нового работадателя в репозиторий в формате DTO
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Возвращает HTTP-код  выполнения операции</returns> 
    [HttpPost]
    public IActionResult Post([FromBody] EmployerPostDto value)
    {
        repository.Employers.Post(mapper.Map<Employer>(value));
        return Ok();
    }

    /// <summary>
    /// Обновляет существующего работадателя в репозитории на основе переданных данных в формате DTO
    /// </summary>
    /// <param name="id">Идентификатор работадателя для обновления</param>
    /// <param name="value">Объект EmployerPutDto с обновленными данными работадателя</param>
    /// <returns>Возвращает HTTP-код  выполнения операции </returns>   
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] EmployerPutDto value)
    {
        if (repository.Employers.Put(id, mapper.Map<Employer>(value)))
            return Ok();
        return NotFound();
    }

    /// <summary>
    /// Удаляет работадателя из репозитория по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор работадателя для удаления</param>
    /// <returns>Возвращает HTTP-код операции</returns> 
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var vacancyToDelete = (from vacancy in repository.Vacancies.GetAll()
                               where vacancy.IdEmployer == id
                               select vacancy);

        var responsesToDelete = (from response in repository.Responses.GetAll()
                                 join vacancy in vacancyToDelete on response.IdVacancy equals vacancy.IdVacancy
                                 select response);
        foreach (var response in responsesToDelete)
        {
            repository.Responses.Delete(response);
        }

        foreach (var vacancy in vacancyToDelete)
        {
            repository.Vacancies.Delete(vacancy.IdVacancy);
        }

        if (repository.Employers.Delete(id))
            return Ok(); 
        return NotFound();
    }
}
