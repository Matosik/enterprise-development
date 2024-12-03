using Microsoft.EntityFrameworkCore;
using EmploymentAgency.Domain.Models;
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
        : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
