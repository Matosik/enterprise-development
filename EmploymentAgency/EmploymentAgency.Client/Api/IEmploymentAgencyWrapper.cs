namespace EmploymentAgency.Client.Api;

public interface IEmploymentAgencyWrapper
{
    Task<ICollection<ApplicantGetDto>> GetAllApplicant();
    Task<ICollection<EmployerGetDto>> GetAllEmployer();
    Task<ICollection<JobPositionGetDto>> GetAllJobPosition();
    Task<ICollection<ResponseGetDto>> GetAllResponse();
    Task<ICollection<ResumeGetDto>> GetAllResume();
    Task<ICollection<VacancyGetDto>> GetAllVacancy();

    Task<ApplicantDto> GetApplicant(int id);
    Task<EmployerDto> GetEmployer(int id);
    Task<JobPositionDto> GetJobPosition(int id);
    Task<ResponseDto> GetResponse(int id);
    Task<ResumeDto> GetResume(int id);
    Task<VacancyDto> GetVacancy(int id);

    Task CreateApplicant(ApplicantPostDto entity);
    Task CreateEmployer(EmployerPostDto entity);
    Task CreateJobPosition(JobPositionPostDto entity);
    Task CreateResponse(int id, ResponsePostDto entity);
    Task CreateResume(int id, ResumePostDto entity);
    Task CreateVacancy(int id, VacancyPostDto entity);


    //Task<bool> UpdateApplicant(int id, ApplicantPutDto entity);
    //Task<bool> UpdateEmployer(int id, EmployerPutDto entity);
    //Task<bool> UpdateJobPosition(int id, JobPositionPutDto entity);
    //Task<bool> UpdateResponse(int id, ResponsePutDto entity);
    //Task<bool> UpdateResume(int id, ResumePutDto entity);
    //Task<bool> UpdateVacancy(int id, VacancyPutDto entity);

    //Task<bool> UpdateApplicant(int id, ApplicantPutDto entity);
    //Task<bool> UpdateEmployer(int id, EmployerPutDto entity);
    //Task<bool> UpdateJobPosition(int id, JobPositionPutDto entity);
    //Task<bool> UpdateResponse(int id, ResponsePutDto entity);
    //Task<bool> UpdateResume(int id, ResumePutDto entity);
    //Task<bool> UpdateVacancy(int id, VacancyPutDto entity);

    Task UpdateApplicant(int id, ApplicantPutDto entity);
    Task UpdateEmployer(int id, EmployerPutDto entity);
    Task UpdateJobPosition(int id, JobPositionPutDto entity);
    Task UpdateResponse(int id, ResponsePutDto entity);
    Task UpdateResume(int id, ResumePutDto entity);
    Task UpdateVacancy(int id, VacancyPutDto entity);

    Task DeleteApplicant(int id);
    Task DeleteEmployer(int id);
    Task DeleteJobposition(int id);
    Task DeleteResponse(int id);
    Task DeleteResume(int id);
    Task DeleteVacancy(int id);

}
