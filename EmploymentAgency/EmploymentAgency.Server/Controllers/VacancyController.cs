using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using AutoMapper;
using EmploymentAgency.Domain.Dto.VacancyDtos;

namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VacancyController(IRepository<Vacancy> repository, IRepository<JobPosition> repositoryJob, IRepository<Employer> repositoryEmployer, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получает список вакансий из репозитория, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <returns>Возвращает HTTP-код ответа и коллекцию объектов Vacancy</returns>
    [HttpGet]
    public async Task<IEnumerable<VacancyGetDto>> Get()
    {
        var vacancies = await repository.GetAllAsync();
        return mapper.Map<IEnumerable<VacancyGetDto>>(vacancies);
    }

    /// <summary>
    /// Получает вакансию из репозитория по Id, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <param name="id">Id ваканчии которую хотим получить</param>
    /// <returns>Возвращает код HTTP-код ответа и найденое значение вакансии по id</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<VacancyDto>> Get(int id)
    {
        var vacancy = await repository.GetByIdAsync(id);
        if (vacancy == null)
            return NotFound();

        return Ok(mapper.Map<VacancyDto>(vacancy));
    }

    /// <summary>
    /// Добавляет новую вакансию в репозиторий в формате DTO
    /// </summary>
    /// <param name="value"></param>
    /// <param name="id">Id Работодателя который создает ваканисю</param>>
    /// <returns>Возвращает HTTP-код  выполнения операции</returns>
    [HttpPost("{id}")]
    public async Task<IActionResult> Post(int id, [FromBody] VacancyPostDto value)
    {
        var jobs = await repositoryJob.GetAllAsync();
        if (await repositoryEmployer.GetByIdAsync(id) == null)
            return NotFound("Такой Employer не найден");

        var job = jobs.FirstOrDefault(j => j.Section == value.Job.Section && j.PositionName == value.Job.PositionName);
        if (job == null)
            return NotFound("Такой JobPosition нет не найдено, но Вы можете создать свою рабочубю поизицию");

        var addedVacancy = mapper.Map<Vacancy>(value);
        addedVacancy.IdEmployer = id;
        addedVacancy.IdJobPosition = job.IdJobPosition;
        try 
        { 
            await repository.PostAsync(addedVacancy); 
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }
    /// <summary>
    /// Обновляет существующую вакансию в репозитории на основе переданных данных в формате DTO
    /// </summary>
    /// <param name="id">Идентификатор вакансии для обновления</param>
    /// <param name="value">Объект VacancyPutDto с обновленными данными вакансии</param>
    /// <returns>Возвращает HTTP-код  выполнения операции </returns>    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] VacancyPutDto value)
    {
        var vacancy = mapper.Map<Vacancy>(value);
        if (await repository.PutAsync(id, vacancy))
            return Ok();
        return NotFound();
    }

    /// <summary>
    /// Удаляет вакансию из репозитория по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор вакансии для удаления</param>
    /// <returns>Возвращает HTTP-код операции</returns>    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (await repository.DeleteAsync(id))
            return Ok();
        return NotFound();
    }
}
