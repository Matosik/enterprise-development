using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using EmploymentAgency.Server.DTO;
using AutoMapper;
namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployerController(IRepository<Employer> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получает список Работодателей из репозитория, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <returns>Возвращает HTTP-код ответа и коллекцию объектов EmployerDto</returns>
    [HttpGet]
    public ActionResult<IEnumerable<EmployerDto>> Get()
    {
        var repoDto = mapper.Map<IEnumerable<EmployerDto>>(repository.GetAll());
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
        var applicant = repository.GetById(id);
        if (applicant == null)
        {
            NotFound();
        }

        return Ok(mapper.Map<EmployerDto>(applicant));
    }

    /// <summary>
    /// Добавляет нового работадателя в репозиторий в формате DTO
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Возвращает HTTP-код  выполнения операции</returns> 
    [HttpPost]
    public IActionResult Post([FromBody] EmployerDto value)
    {
        repository.Post(mapper.Map<Employer>(value));

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
        if (repository.Put(id, mapper.Map<Employer>(value)))
        {
            return Ok();
        }
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
        if (repository.Delete(id)) { return Ok(); }
        return NotFound();
    }
}
