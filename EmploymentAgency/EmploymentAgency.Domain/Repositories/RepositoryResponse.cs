using EmploymentAgency.Domain.Models;

namespace EmploymentAgency.Domain.Repositories;

public class RepositoryResponse : IRepository<Response>
{
    private int _id = 0;
    private readonly List<Response> _responses = [];

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

    public void Post(Response response)
    {
        _responses.Add(response);
    }
    public bool Delete(int id)
    {
        var response = GetById(id);
        if (response == null) return false;
        _responses.Remove(response);
        return true;
    }
}
