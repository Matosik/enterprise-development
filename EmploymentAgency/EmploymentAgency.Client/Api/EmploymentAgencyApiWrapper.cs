
namespace EmploymentAgency.Client.Api;

public class EmploymentAgencyApiWrapper(IConfiguration configuration) : IEmploymentAgencyWrapper
{
    public readonly EmploymentAgencyClient _client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

    public async Task CreateApplicant(ApplicantPostDto entity) => await _client.ApplicantPOSTAsync(entity);
    public async Task CreateEmployer(EmployerPostDto entity) => await _client.EmployerPOSTAsync(entity);
    public async Task CreateJobPosition(JobPositionPostDto entity) => await _client.JobPositionPOSTAsync(entity);
    public async Task CreateResponse(int id, ResponsePostDto entity) => await _client.ResponsePOSTAsync(id, entity);
    public async Task CreateResume(int id, ResumePostDto entity) => await _client.ResumePOSTAsync(id, entity);
    public async Task CreateVacancy(int id, VacancyPostDto entity) => await _client.VacancyPOSTAsync(id, entity);

    public async Task DeleteApplicant(int id) => await _client.ApplicantDELETEAsync(id);
    public async Task DeleteEmployer(int id) => await _client.EmployerDELETEAsync(id);
    public async Task DeleteJobposition(int id) => await _client.JobPositionDELETEAsync(id);
    public async Task DeleteResponse(int id) => await _client.ResponseDELETEAsync(id);
    public async Task DeleteResume(int id) => await _client.ResumeDELETEAsync(id);
    public async Task DeleteVacancy(int id) => await _client.VacancyDELETEAsync(id);


    public async Task<ICollection<ApplicantGetDto>> GetAllApplicant() => await _client.ApplicantAllAsync();
    public async Task<ICollection<EmployerGetDto>> GetAllEmployer() => await _client.EmployerAllAsync();
    public async Task<ICollection<JobPositionGetDto>> GetAllJobPosition() => await _client.JobPositionAllAsync();
    public async Task<ICollection<ResponseGetDto>> GetAllResponse() => await _client.ResponseAllAsync();
    public async Task<ICollection<ResumeGetDto>> GetAllResume() => await _client.ResumeAllAsync();
    public async Task<ICollection<VacancyGetDto>> GetAllVacancy() => await _client.VacancyAllAsync();

    public async Task<ApplicantDto> GetApplicant(int id) => await _client.ApplicantGETAsync(id);
    public async Task<EmployerDto> GetEmployer(int id) => await _client.EmployerGETAsync(id);
    public async Task<JobPositionDto> GetJobPosition(int id) => await _client.JobPositionGETAsync(id);
    public async Task<ResponseDto> GetResponse(int id) => await _client.ResponseGETAsync(id);
    public async Task<ResumeDto> GetResume(int id) => await _client.ResumeGETAsync(id);
    public async Task<VacancyDto> GetVacancy(int id) => await _client.VacancyGETAsync(id);

    public async Task UpdateApplicant(int id, ApplicantPutDto entity) => await _client.ApplicantPUTAsync(id, entity);
    public async Task UpdateEmployer(int id, EmployerPutDto entity) => await _client.EmployerPUTAsync(id, entity);
    public async Task UpdateJobPosition(int id, JobPositionPutDto entity) => await _client.JobPositionPUTAsync(id, entity);
    public async Task UpdateResponse(int id, ResponsePutDto entity) => await _client.ResponsePUTAsync(id, entity);
    public async Task UpdateResume(int id, ResumePutDto entity) => await _client.ResumePUTAsync(id, entity);
    public async Task UpdateVacancy(int id, VacancyPutDto entity) => await _client.VacancyPUTAsync(id, entity);
}
