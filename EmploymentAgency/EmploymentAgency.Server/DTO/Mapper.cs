using AutoMapper;
using EmploymentAgency.Domain.Models;
namespace EmploymentAgency.Server.DTO;


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

    }
}
