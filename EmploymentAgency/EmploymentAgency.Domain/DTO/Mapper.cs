using AutoMapper;
using EmploymentAgency.Domain.Models;
namespace EmploymentAgency.Domain.DTO;

/// <summary>
/// Маппер для конвертации обычных данных в DTO и обратно 
/// </summary>
public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Applicant, ApplicantDto>().ReverseMap();
        CreateMap<Applicant, ApplicantPutDto>().ReverseMap();
        CreateMap<Employer, EmployerDto>().ReverseMap();
        CreateMap<Employer, EmployerPutDto>().ReverseMap();
        CreateMap<JobPosition, JobPositionDto>().ReverseMap();
        CreateMap<Response, ResponseDto>().ReverseMap();
        CreateMap<Response, ResponsePutDto>().ReverseMap();
        CreateMap<Resume, ResumeDto>().ReverseMap();
        CreateMap<Resume, ResumePutDto>().ReverseMap();
        CreateMap<Resume, ResumePostDto>().ReverseMap();
        CreateMap<Vacancy, VacancyDto>().ReverseMap();
        CreateMap<Vacancy, VacancyPutDto>().ReverseMap();
        CreateMap<Vacancy, VacancyPostDto>().ReverseMap();
    }
}
