using AutoMapper;
using EmploymentAgency.Domain.Models;
namespace EmploymentAgency.Server.DTO;


public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Applicant, ApplicantDto>().ReverseMap();
        CreateMap<Employer, EmployerDto>().ReverseMap();
        CreateMap<JobPosition, JobPositionDto>().ReverseMap();
        CreateMap<Response, ResponseDto>().ReverseMap();
        CreateMap<Resume, ResumeDto>().ReverseMap(); 
    }
}
