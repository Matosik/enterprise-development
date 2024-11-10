using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using EmploymentAgency.Server.DTO;
using AutoMapper;
namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResumeController(IRepository<Resume> repository, IMapper mapper) : ControllerBase
{
    // GET ALL
    [HttpGet]
    public ActionResult<IEnumerable<ResumeDto>> Get()
    {
        var repoDto = mapper.Map<IEnumerable<ResumeDto>>(repository.GetAll());
        return Ok(repoDto);
    }

    // GET id
    [HttpGet("{id}")]
    public ActionResult<ResumeDto> Get(int id)
    {
        var job = repository.GetById(id);
        if (job == null)
        {
            NotFound();
        }

        return Ok(mapper.Map<ResumeDto>(job));
    }

    // POST 
    [HttpPost]
    public IActionResult Post([FromBody] ResumeDto value)
    {
        repository.Post(mapper.Map<Resume>(value));

        return Ok();
    }

    // PUT 
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ResumePutDto value)
    {
        if (repository.Put(id, mapper.Map<Resume>(value)))
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
