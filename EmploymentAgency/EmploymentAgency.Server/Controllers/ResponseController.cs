using Microsoft.AspNetCore.Mvc;
using EmploymentAgency.Domain.Repositories;
using EmploymentAgency.Domain.Models;
using EmploymentAgency.Server.DTO;
using AutoMapper;
namespace EmploymentAgency.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResponseController(IRepository<Response> repository, IMapper mapper) : ControllerBase
{
    // GET ALL
    [HttpGet]
    public ActionResult<IEnumerable<ResponseDto>> Get()
    {
        var repoDto = mapper.Map<IEnumerable<ResponseDto>>(repository.GetAll());
        return Ok(repoDto);
    }

    // GET id
    [HttpGet("{id}")]
    public ActionResult<ResponseDto> Get(int id)
    {
        var job = repository.GetById(id);
        if (job == null)
        {
            NotFound();
        }

        return Ok(mapper.Map<ResponseDto>(job));
    }

    // POST 
    [HttpPost]
    public IActionResult Post([FromBody] ResponseDto value)
    {
        repository.Post(mapper.Map<Response>(value));

        return Ok();
    }

    // PUT 
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ResponsePutDto value)
    {
        if (repository.Put(id, mapper.Map<Response>(value)))
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
