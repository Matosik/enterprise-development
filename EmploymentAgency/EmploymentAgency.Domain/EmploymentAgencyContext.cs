using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmploymentAgency.Domain.Models;
using System.Reflection.Emit;
namespace EmploymentAgency.Domain;

public class EmploymentAgencyContext : DbContext
{
    public DbSet<Applicant> Applicants { get; set; } = null!;
    public DbSet<Employer> Employers { get; set; } = null!;
    public DbSet<Vacancy> Vacancies { get; set; } = null!;
    public DbSet<Resume> Resumes { get; set; } = null!;
    public DbSet<Response> Responses { get; set; } = null!;
    public DbSet<JobPosition> JobPositions { get; set; } = null!;
    public EmploymentAgencyContext()
    {
        Database.EnsureCreated();
    }
    public EmploymentAgencyContext(DbContextOptions<EmploymentAgencyContext> options)
        : base(options)  // Передаем options в базовый конструктор
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Связь между Resume и Applicant через внешний ключ IdApplicant
        modelBuilder.Entity<Resume>()
            .HasOne<Applicant>() // Указываем, что Resume ссылается на Applicant
            .WithMany() // Указываем, что у Applicant может быть несколько резюме
            .HasForeignKey(r => r.IdApplicant); // Настроили внешний ключ IdApplicant


        modelBuilder.Entity<Response>()
            .HasOne<Vacancy>()
            .WithMany()
            .HasForeignKey(r => r.IdVacancy);

        modelBuilder.Entity<Response>()
            .HasOne<Applicant>()
            .WithMany()
            .HasForeignKey(r => r.IdApplicant);

        modelBuilder.Entity<Vacancy>()
            .HasOne<Employer>()
            .WithMany()
            .HasForeignKey(v => v.IdEmployer);

        modelBuilder.Entity<Vacancy>()
            .HasOne<JobPosition>()
            .WithMany()
            .HasForeignKey(v => v.IdJobPosition);

        modelBuilder.Entity<Resume>()
            .HasOne<JobPosition>()
            .WithMany()
            .HasForeignKey(r => r.IdPosition);
        base.OnModelCreating(modelBuilder);
    }

}
