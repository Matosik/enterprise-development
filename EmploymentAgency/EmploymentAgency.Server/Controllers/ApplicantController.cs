using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using EmploymentAgency.Domain.DTO;
using AutoMapper;

namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicantController(ServiseRepository repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получает список соискателей работы из репозитория, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <returns>Возвращает HTTP-код ответа и коллекцию объектов ApplicantDto</returns>
    [HttpGet]
    public ActionResult<IEnumerable<ApplicantDto>> Get()
    {
        var repoDto = mapper.Map<IEnumerable<ApplicantDto>>(repository.Applicants.GetAll());
        return Ok(repoDto);
    }

    /// <summary>
    /// Получает соискателя работы из репозитория по Id, в формате DTO и возвращает результат с кодом выполнения
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Возвращает код HTTP-код ответа и найденое значение соискателя работы по id</returns>
    [HttpGet("{id}")]
    public ActionResult<ApplicantDto> Get(int id)
    {
        var applicant = repository.Applicants.GetById(id);
        if (applicant == null)
            return NotFound();

        return Ok(mapper.Map<ApplicantDto>(applicant));
    }

    /// <summary>
    /// Добавляет нового соискателя работы в репозиторий в формате DTO
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Возвращает HTTP-код  выполнения операции</returns> 
    [HttpPost]
    public IActionResult Post([FromBody] ApplicantDto value)
    {
        var applicant = mapper.Map<Applicant>(value);
        repository.Applicants.Post(applicant);
        return Ok();
    }

    /// <summary>
    /// Обновляет существующую соискателя работы в репозитории на основе переданных данных в формате DTO
    /// </summary>
    /// <param name="id">Идентификатор соискателя работы для обновления</param>
    /// <param name="value">Объект ApplicantPutDto с обновленными данными соискателя работы</param>
    /// <returns>Возвращает HTTP-код  выполнения операции </returns>     
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ApplicantPutDto value)
    {
        if (repository.Applicants.Put(id, mapper.Map<Applicant>(value)))
            return Ok();
        return NotFound();
    }

    /// <summary>
    /// Удаляет соискателя работы из репозитория по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор соискателя работы для удаления</param>
    /// <returns>Возвращает HTTP-код операции</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {

        var responseToDelete = (from response in repository.Responses.GetAll()
                                where response.IdApplicant == id
                                select response);

        var resumeToDelete = (from resume in repository.Resumes.GetAll()
                              where resume.IdApplicant == id
                              select resume);

        foreach (var response in responseToDelete)
        {
            repository.Responses.Delete(response.IdResponse);
        }

        foreach (var resume in resumeToDelete)
        {
            repository.Resumes.Delete(resume.IdResume);
        }

        if (repository.Applicants.Delete(id)) 
            return Ok();
        return NotFound();
    }
}
