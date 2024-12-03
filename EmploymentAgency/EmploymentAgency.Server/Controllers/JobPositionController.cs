using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using AutoMapper;
using EmploymentAgency.Domain.Dto.JobPositionDtos;
using EmploymentAgency.Domain.Dto.ResponseDtos;

namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobPositionController(IRepository<JobPosition> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получает список рабочих позиций из репозитория, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <returns>Возвращает HTTP-код ответа и коллекцию объектов JobPosition</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobPositionGetDto>>> Get()
    {
        var jobs = await repository.GetAllAsync();
        return Ok(mapper.Map<IEnumerable<JobPositionGetDto>>(jobs));
    }

    /// <summary>
    /// Получает рабочую позицию из репозитория по Id, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <param name="id">Id рабочей позиции данные, которй мы хотим получить </param>
    /// <returns>Возвращает код HTTP-код ответа и найденое значение рабочая позиция по id</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<JobPositionDto>> Get(int id)
    {
        var job = await repository.GetByIdAsync(id);
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
    public async Task<IActionResult> Post([FromBody] JobPositionPostDto value)
    {

        try 
        { 
            await repository.PostAsync(mapper.Map<JobPosition>(value)); 
        }
        catch(Exception ex) 
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }

    /// <summary>
    /// Обновляет существующую рабочую позицию в репозитории на основе переданных данных в формате DTO
    /// </summary>
    /// <param name="id">Идентификатор рабочей позиции для обновления</param>
    /// <param name="value">Объект JobPositionDto с обновленными данными рабочая позиция</param>
    /// <returns>Возвращает HTTP-код  выполнения операции </returns> 
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] JobPositionPutDto value)
    {
        if (await repository.PutAsync(id, mapper.Map<JobPosition>(value)))
            return Ok();
        return NotFound();
    }

    /// <summary>
    /// Удаляет рабочую позицию из репозитория по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор рабочей позиции для удаления</param>
    /// <returns>Возвращает HTTP-код операции</returns> 
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (await repository.DeleteAsync(id))
            return Ok();
        return NotFound();
    }
}
