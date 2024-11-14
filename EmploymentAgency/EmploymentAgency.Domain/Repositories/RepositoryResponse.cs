using EmploymentAgency.Domain.Models;

namespace EmploymentAgency.Domain.Repositories;

public class RepositoryResponse : IRepository<Response>
{
    private int _id;
    private readonly List<Response> _responses = [];
    public RepositoryResponse()
    {
        _responses = new EmploymentAgencyData().Responses;
        _id = _responses.Count > 0 ? _responses.Max(a => a.IdResponse) + 1 : 0;
    }
    public Response? GetById(int id) => _responses.Find(r => r.IdResponse == id);

    public IEnumerable<Response> GetAll() => _responses;

    public void Overwrite(ref Response old, Response update)
    {
        old.Status = update.Status;
        old.SummaryResponse = update.SummaryResponse;
        old.IdApplicant = update.IdApplicant; // Организовать проверку существует ли такой Id Vacancy
        old.IdVacancy = update.IdVacancy;// Организовать проверку существует ли такой Id Vacancy
        old.DateResponse = update.DateResponse;
    }

    public Response Post(Response response)
    {
        response.IdResponse = _id++;
        _responses.Add(response);
        return response;
    }
    public void Delete(Response response)
    {
        _responses.Remove(response);
    }
    public bool Delete(int id)
    {
        var response = GetById(id);
        if (response == null) 
            return false;
        Delete(response);
        return true;
    }
}
