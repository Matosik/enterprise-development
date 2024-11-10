using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using EmploymentAgency.Server.DTO;
using AutoMapper;
namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobPositionController(IRepository<JobPosition> repository, IMapper mapper) : ControllerBase
{
    // GET ALL
    [HttpGet]
    public ActionResult<IEnumerable<JobPositionDto>> Get()
    {
        var repoDto = mapper.Map<IEnumerable<JobPositionDto>>(repository.GetAll());
        return Ok(repoDto);
    }

    // GET id
    [HttpGet("{id}")]
    public ActionResult<JobPositionDto> Get(int id)
    {
        var job = repository.GetById(id);
        if (job == null)
        {
            NotFound();
        }

        return Ok(mapper.Map<JobPositionDto>(job));
    }

    // POST 
    [HttpPost]
    public IActionResult Post([FromBody] JobPositionDto value)
    {
        repository.Post(mapper.Map<JobPosition>(value));

        return Ok();
    }

    // PUT 
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] JobPositionDto value)
    {
        if (repository.Put(id, mapper.Map<JobPosition>(value)))
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
