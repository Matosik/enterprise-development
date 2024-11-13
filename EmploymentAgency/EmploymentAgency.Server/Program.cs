using EmploymentAgency.Domain.DTO;
using EmploymentAgency.Domain.Models;
using EmploymentAgency.Domain.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRepository<Applicant>, RepositoryApplicant>();
builder.Services.AddSingleton<IRepository<Employer>, RepositoryEmployer>();
builder.Services.AddSingleton<IRepository<JobPosition>, RepositoryJobPosition>();
builder.Services.AddSingleton<IRepository<Response>, RepositoryResponse>();
builder.Services.AddSingleton<IRepository<Resume>, RepositoryResume>();
builder.Services.AddSingleton<IRepository<Vacancy>, RepositoryVacancy>();

builder.Services.AddSingleton<ServiseRepository>();


builder.Services.AddAutoMapper(typeof(Mapper));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.Run();
