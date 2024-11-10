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
    // GET ALL
    [HttpGet]
    public ActionResult<IEnumerable<EmployerDto>> Get()
    {
        var repoDto = mapper.Map<IEnumerable<EmployerDto>>(repository.GetAll());
        return Ok(repoDto);
    }

    // GET id
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

    // POST 
    [HttpPost]
    public IActionResult Post([FromBody] EmployerDto value)
    {
        repository.Post(mapper.Map<Employer>(value));

        return Ok();
    }

    // PUT 
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] EmployerPutDto value)
    {
        if (repository.Put(id, mapper.Map<Employer>(value)))
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
