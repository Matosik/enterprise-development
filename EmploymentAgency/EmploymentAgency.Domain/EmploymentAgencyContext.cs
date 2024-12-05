using Microsoft.EntityFrameworkCore;
using EmploymentAgency.Domain.Models;
namespace EmploymentAgency.Domain;

public class EmploymentAgencyContext : DbContext
{
    public DbSet<Applicant> Applicants { get; set; } 
    public DbSet<Employer> Employers { get; set; } 
    public DbSet<Vacancy> Vacancies { get; set; } 
    public DbSet<Resume> Resumes { get; set; } 
    public DbSet<Response> Responses { get; set; } 
    public DbSet<JobPosition> JobPositions { get; set; } 
    public EmploymentAgencyContext()
    {
        Database.EnsureCreated();
    }
    public EmploymentAgencyContext(DbContextOptions<EmploymentAgencyContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>()
            .HasIndex(a=> a.Number)
            .IsUnique();

        modelBuilder.Entity<Employer>()
            .HasIndex(e => e.Number)
            .IsUnique();

        modelBuilder.Entity<Resume>()
            .HasOne<Applicant>()
            .WithMany()
            .HasForeignKey(r => r.IdApplicant);

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
