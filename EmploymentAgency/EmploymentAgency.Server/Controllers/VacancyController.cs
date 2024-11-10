using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using EmploymentAgency.Server.DTO;
using AutoMapper;
namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VacancyController(IRepository<Vacancy> repository, IMapper mapper) : ControllerBase
{
    // GET ALL
    [HttpGet]
    public ActionResult<IEnumerable<VacancyDto>> Get()
    {
        var repoDto = mapper.Map<IEnumerable<VacancyDto>>(repository.GetAll());
        return Ok(repoDto);
    }

    // GET id
    [HttpGet("{id}")]
    public ActionResult<VacancyDto> Get(int id)
    {
        var job = repository.GetById(id);
        if (job == null)
        {
            NotFound();
        }

        return Ok(mapper.Map<VacancyDto>(job));
    }

    // POST 
    [HttpPost]
    public IActionResult Post([FromBody] VacancyDto value)
    {
        repository.Post(mapper.Map<Vacancy>(value));

        return Ok();
    }

    // PUT 
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] VacancyPutDto value)
    {
        if (repository.Put(id, mapper.Map<Vacancy>(value)))
        {
            return Ok();
        }
        return NotFound();
    }

    // DELETE 
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (repository.Delete(id)) { return Ok(); }
        return NotFound();
    }
}
