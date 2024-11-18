using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using AutoMapper;
using EmploymentAgency.Domain.Dto.ResponseD;

namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResponseController(ServiseRepository repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получает список откликов из репозитория, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <returns>Возвращает HTTP-код ответа и коллекцию объектов ResponseDto</returns>
    [HttpGet]
    public ActionResult<IEnumerable<ResponseGetDto>> Get()
    {
        return Ok(mapper.Map<IEnumerable<ResponseGetDto>>(repository.Responses.GetAll()));
    }

    /// <summary>
    /// Получает отклик из репозитория по Id, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Возвращает код HTTP-код ответа и найденое значение отклик по id</returns>
    [HttpGet("{id}")]
    public ActionResult<ResponseDto> Get(int id)
    {
        var job = repository.Responses.GetById(id);
        if (job == null)
            return NotFound();

        return Ok(mapper.Map<ResponseDto>(job));
    }

    /// <summary>
    /// Добавляет новое отклик в репозиторий в формате DTO
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Возвращает HTTP-код  выполнения операции</returns> 
    [HttpPost]
    public IActionResult Post([FromBody] ResponsePostDto value)
    {
        if(repository.Resumes.GetById(value.IdResume) == null)
            return NotFound("Резюме с таким ID не найден");

        if (repository.Applicants.GetById(value.IdApplicant) == null)
            return NotFound("Applicant с таким ID не найден");

        if (repository.Vacancies.GetById(value.IdVacancy) == null)
            return NotFound("Вакансяи с таким ID не найден");
        repository.Responses.Post(mapper.Map<Response>(value));

        return Ok();
    }

    /// <summary>
    /// Обновляет существующую отклик в репозитории на основе переданных данных в формате DTO
    /// </summary>
    /// <param name="id">Идентификатор отклик для обновления</param>
    /// <param name="value">Объект ResponsePutDto с обновленными данными отклик</param>
    /// <returns>Возвращает HTTP-код  выполнения операции </returns>   
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ResponsePutDto value)
    {
        if (repository.Responses.Put(id, mapper.Map<Response>(value)))
            return Ok();
        return NotFound();
    }

    /// <summary>
    /// Удаляет отклик из репозитория по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор отклик для удаления</param>
    /// <returns>Возвращает HTTP-код операции</returns> 
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (repository.Responses.Delete(id))
            return Ok();
        return NotFound();
    }
}
