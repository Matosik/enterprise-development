
using EmploymentAgency.Server.DTO;
using EmploymentAgency.Domain;
using EmploymentAgency.Domain.Models;
using EmploymentAgency.Domain.Repositories;
var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
