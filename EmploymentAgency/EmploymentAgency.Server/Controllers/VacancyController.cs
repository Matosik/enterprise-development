using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using AutoMapper;
using EmploymentAgency.Domain.Dto.VacancyDtos;
using EmploymentAgency.Domain.Dto.ResumeDtos;

namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VacancyController(ServiseRepository repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получает список вакансий из репозитория, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <returns>Возвращает HTTP-код ответа и коллекцию объектов Vacancy</returns>
    [HttpGet]
    public async Task<IEnumerable<VacancyGetDto>> Get()
    {
        var vacancies = await repository.Vacancies.GetAllAsync();
        return mapper.Map<IEnumerable<VacancyGetDto>>(vacancies);
    }

    /// <summary>
    /// Получает вакансию из репозитория по Id, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Возвращает код HTTP-код ответа и найденое значение вакансии по id</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<VacancyDto>> Get(int id)
    {
        var vacancy = await repository.Vacancies.GetByIdAsync(id);
        if (vacancy == null)
            return NotFound();

        return Ok(mapper.Map<VacancyDto>(vacancy));
    }

    /// <summary>
    /// Добавляет новую вакансию в репозиторий в формате DTO
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Возвращает HTTP-код  выполнения операции</returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] VacancyPostDto value)
    {
        //string message = "Создание Вакансии прошло успешно";
        //if (repository.Employers.GetById(value.IdEmployer) == null)
        //    return NotFound("Работодатель с таким ID не найден");
        //var jobs = repository.Jobs.GetAll();
        //var cur = value.Job;
        //JobPosition? job;

        //job = jobs.FirstOrDefault(s => s.PositionName == cur.PositionName && s.Section == cur.Section);
        //if (job == null)
        //{
        //    job = repository.Jobs.Post(mapper.Map<JobPosition>(value.Job));
        //    message += "\nТакой рабочей позиции нет, но спецально для вас добавили";
        //}
        //var added = mapper.Map<Vacancy>(value);
        //added.IdJobPosition = job.IdJobPosition;
        await repository.Vacancies.PostAsync(mapper.Map<Vacancy>(value));
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
        if (await repository.Vacancies.PutAsync(id, vacancy))
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
        //await repository.Responses.GetAllAsync()
        //    .Where(r => r.IdVacancy == id)
        //    .ToList()
        //    .ForEach(r => repository.Responses.Delete(r.IdResponse));
        if (await repository.Vacancies.DeleteAsync(id))
            return Ok();
        return NotFound();
    }
}
