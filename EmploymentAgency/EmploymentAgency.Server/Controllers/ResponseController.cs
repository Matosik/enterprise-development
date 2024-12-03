using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using AutoMapper;
using EmploymentAgency.Domain.Dto.ResponseDtos;
using EmploymentAgency.Domain.Dto.ResumeDtos;

namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResponseController(IRepository<Response> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получает список откликов из репозитория, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <returns>Возвращает HTTP-код ответа и коллекцию объектов ResponseDto</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResponseGetDto>>> Get()
    {
        var responses = await repository.GetAllAsync();
        return Ok(mapper.Map<IEnumerable<ResponseGetDto>>(responses));
    }

    /// <summary>
    /// Получает отклик из репозитория по Id, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Возвращает код HTTP-код ответа и найденое значение отклик по id</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ResponseDto>> Get(int id)
    {
        var response = await repository.GetByIdAsync(id);
        if (response == null)
            return NotFound();
        return Ok(mapper.Map<ResponseDto>(response));
    }

    /// <summary>
    /// Добавляет новое отклик в репозиторий в формате DTO
    /// </summary>
    /// <param name="value"></param>
    /// <param name="id">Id Кандидата, который оставляет отклик</param>
    /// <returns>Возвращает HTTP-код  выполнения операции</returns> 
    [HttpPost("{id}")]
    public async Task<IActionResult> Post(int id,[FromBody] ResponsePostDto value)
    {
        var added = mapper.Map<Response>(value);
        if (value.IdResume == null) // по идее это mapper должен делать но чет у меня не получилосьб и я сделал ручками 
            added.IdResume = null;
        added.IdApplicant = id;
        try
        {
            await repository.PostAsync(added);
        }
        catch (Exception ex)
        {
            NotFound(ex.Message);
        }
        return Ok();
    }

    /// <summary>
    /// Обновляет существующую отклик в репозитории на основе переданных данных в формате DTO
    /// </summary>
    /// <param name="id">Идентификатор отклик для обновления</param>
    /// <param name="value">Объект ResponsePutDto с обновленными данными отклик</param>
    /// <returns>Возвращает HTTP-код  выполнения операции </returns>   
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ResponsePutDto value)
    {
        if (await repository.PutAsync(id, mapper.Map<Response>(value)))
            return Ok();
        return NotFound();
    }

    /// <summary>
    /// Удаляет отклик из репозитория по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор отклик для удаления</param>
    /// <returns>Возвращает HTTP-код операции</returns> 
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (await repository.DeleteAsync(id))
            return Ok();
        return NotFound();
    }
}
