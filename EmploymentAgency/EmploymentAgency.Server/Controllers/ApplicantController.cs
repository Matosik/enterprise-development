using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using EmploymentAgency.Server.DTO;
using AutoMapper;
namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicantController(IRepository<Applicant> repository, IMapper mapper) : ControllerBase
{
    // GET ALL
    [HttpGet]
    public ActionResult<IEnumerable<ApplicantDto>> Get()
    {
        var repoDto = mapper.Map<IEnumerable<ApplicantDto>>(repository.GetAll());
        return Ok(repoDto);
    }

    // GET id
    [HttpGet("{id}")]
    public ActionResult<ApplicantDto> Get(int id)
    {
        var applicant = repository.GetById(id);
        if (applicant == null)
        {
            NotFound();
        }

        return Ok(mapper.Map<ApplicantDto>(applicant));
    }

    // POST 
    [HttpPost]
    public IActionResult Post([FromBody] ApplicantDto value)
    {

        var applicant = mapper.Map<Applicant>(value);
        repository.Post(applicant);

        return Ok();
    }

    // PUT 
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ApplicantPutDto value)
    {
        if (repository.Put(id, mapper.Map<Applicant>(value)))
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
