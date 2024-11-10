
using EmploymentAgency.Server.DTO;
using EmploymentAgency.Domain.Models;
using EmploymentAgency.Domain.Repositories;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRepository<Applicant>, RepositoryApplicant>();
builder.Services.AddSingleton<IRepository<Employer>, RepositoryEmployer>();
builder.Services.AddSingleton<IRepository<JobPosition>, RepositoryJobPosition>();
builder.Services.AddSingleton<IRepository<Response>, RepositoryResponse>();
builder.Services.AddSingleton<IRepository<Resume>, RepositoryResume>();
builder.Services.AddSingleton<IRepository<Vacancy>, RepositoryVacancy>();

builder.Services.AddAutoMapper(typeof(Mapper));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.Run();
