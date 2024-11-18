﻿using AutoMapper;
using EmploymentAgency.Domain.Dto.ApplicantD;
using EmploymentAgency.Domain.Dto.EmployerD;
using EmploymentAgency.Domain.Dto.JobPositionD;
using EmploymentAgency.Domain.Dto.ResponseD;
using EmploymentAgency.Domain.Dto.ResumeD;
using EmploymentAgency.Domain.Dto.VacancyD;
using EmploymentAgency.Domain.Models;

namespace EmploymentAgency.Domain.Dto;
/// <summary>
/// Маппер для конвертации обычных данных в DTO и обратно 
/// </summary>
public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Applicant, ApplicantDto>().ReverseMap();
        CreateMap<Applicant, ApplicantPostDto>().ReverseMap();
        CreateMap<Applicant, ApplicantGetDto>().ReverseMap();
        CreateMap<Applicant, ApplicantPutDto>().ReverseMap();

        CreateMap<Employer, EmployerDto>().ReverseMap();
        CreateMap<Employer, EmployerPutDto>().ReverseMap();
        CreateMap<Employer, EmployerGetDto>().ReverseMap();
        CreateMap<Employer, EmployerPostDto>().ReverseMap();
        CreateMap<Employer, EmployerWithVacancyCountDto>().ReverseMap();

        CreateMap<JobPosition, JobPositionDto>().ReverseMap();
        CreateMap<JobPosition, JobPositionPutDto>().ReverseMap();
        CreateMap<JobPosition, JobPositionPostDto>().ReverseMap();
        CreateMap<JobPosition, JobPositionGetDto>().ReverseMap();

        CreateMap<Response, ResponseDto>().ReverseMap();
        CreateMap<Response, ResponsePutDto>().ReverseMap();
        CreateMap<Response, ResponsePostDto>().ReverseMap();
        CreateMap<Response, ResponseGetDto>().ReverseMap();

        CreateMap<Resume, ResumeDto>().ReverseMap();
        CreateMap<Resume, ResumeGetDto>().ReverseMap();
        CreateMap<Resume, ResumePutDto>().ReverseMap();
        CreateMap<Resume, ResumePostDto>().ReverseMap();

        CreateMap<Vacancy, VacancyDto>().ReverseMap();
        CreateMap<Vacancy, VacancyPutDto>().ReverseMap();
        CreateMap<Vacancy, VacancyPostDto>().ReverseMap();
        CreateMap<Vacancy, VacancyGetDto>().ReverseMap();
    }
}
