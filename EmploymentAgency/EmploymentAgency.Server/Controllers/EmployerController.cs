using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using AutoMapper;
using EmploymentAgency.Domain.Dto.EmployerDtos;
using EmploymentAgency.Domain.Dto.ResponseDtos;

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
    public async Task<ActionResult<IEnumerable<EmployerGetDto>>> Get()
    {
        var employers = await repository.Employers.GetAllAsync();
        return Ok(mapper.Map<IEnumerable<EmployerGetDto>>(employers));
    }

    /// <summary>
    /// Получает работадателя из репозитория по Id, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Возвращает код HTTP-код ответа и найденое значение работадатель по id</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<EmployerDto>> Get(int id)
    {
        var employer = await repository.Employers.GetByIdAsync(id);
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
    public async Task<IActionResult> Post([FromBody] EmployerPostDto value)
    {
        await repository.Employers.PostAsync(mapper.Map<Employer>(value));
        return Ok();
    }

    /// <summary>
    /// Обновляет существующего работадателя в репозитории на основе переданных данных в формате DTO
    /// </summary>
    /// <param name="id">Идентификатор работадателя для обновления</param>
    /// <param name="value">Объект EmployerPutDto с обновленными данными работадателя</param>
    /// <returns>Возвращает HTTP-код  выполнения операции </returns>   
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] EmployerPutDto value)
    {
        if (await repository.Employers.PutAsync(id, mapper.Map<Employer>(value)))
            return Ok();
        return NotFound();
    }

    /// <summary>
    /// Удаляет работадателя из репозитория по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор работадателя для удаления</param>
    /// <returns>Возвращает HTTP-код операции</returns> 
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        //repository.Responses.GetAll()
        //    .Where(r => repository.Vacancies.GetAll()
        //        .Where(v => v.IdEmployer == id)
        //        .Select(v => v.IdVacancy)
        //        .Contains(r.IdVacancy))
        //    .ToList()
        //    .ForEach(r => repository.Responses.Delete(r.IdResponse));

        //repository.Vacancies.GetAll()
        //    .Where(r => r.IdEmployer == id)
        //    .ToList()
        //    .ForEach(r => repository.Vacancies.Delete(r.IdVacancy));

        if (await repository.Employers.DeleteAsync(id))
            return Ok();
        return NotFound();
    }
}
