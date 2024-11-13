using EmploymentAgency.Domain.Models;

namespace EmploymentAgency.Domain.Repositories;

public class ServiseRepository
    (
        IRepository<Vacancy> repositoryVacancy,
        IRepository<Applicant> repositoryApplicant,
        IRepository<Employer> repositoryEmployer,
        IRepository<JobPosition> repositoryJob,
        IRepository<Response> repositoryResponse,
        IRepository<Resume> repositoryResume
    )
{
    public required IRepository<Vacancy> Vacancies = repositoryVacancy;
    public required IRepository<Applicant> Applicants = repositoryApplicant;
    public required IRepository<Employer> Employers = repositoryEmployer;
    public required IRepository<JobPosition> Jobs = repositoryJob;
    public required IRepository<Response> Responses = repositoryResponse;
    public required IRepository<Resume> Resumes = repositoryResume;
}
