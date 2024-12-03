using EmploymentAgency.Domain;
using EmploymentAgency.Domain.Dto;
using EmploymentAgency.Domain.Models;
using EmploymentAgency.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen
    (
        options =>
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        }
    );
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmploymentAgencyContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("MySQL"), new MySqlServerVersion(new Version(8, 0, 4))));

builder.Services.AddScoped<IRepository<Applicant>, RepositoryApplicant>();
builder.Services.AddScoped<IRepository<Employer>, RepositoryEmployer>();
builder.Services.AddScoped<IRepository<JobPosition>, RepositoryJobPosition>();
builder.Services.AddScoped<IRepository<Resume>, RepositoryResume>();
builder.Services.AddScoped<IRepository<Vacancy>, RepositoryVacancy>();
builder.Services.AddScoped<IRepository<Response>, RepositoryResponse>();

builder.Services.AddScoped<ServiseRepository>();

builder.Services.AddAutoMapper(typeof(Mapper));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.Run();
