using EmployeesCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesCRUD;

public class DataBaseContext : DbContext
{
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;

    public DataBaseContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        ;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .SetBasePath(Directory.GetCurrentDirectory())
            .Build();
        optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(x => x.DepartmentId);

        modelBuilder.Entity<JobTitle>()
            .HasMany(j => j.Employees)
            .WithOne(e => e.JobTitle)
            .HasForeignKey(x => x.CurrentJobTitle);

        modelBuilder.Entity<JobTitle>()
            .HasKey(x => x.Title);

        modelBuilder.Entity<JobTitle>()
            .Property(x => x.Title)
            .HasConversion<string>();

        modelBuilder.Entity<Employee>()
            .Property(x => x.CurrentJobTitle)
            .HasConversion<string>();

        modelBuilder.Entity<JobTitle>()
            .HasData(new List<JobTitle>()
            {
                new JobTitle()
                {
                    Title = JobTitle.JobTitles.Junior,
                    Salary = 8000
                },
                new JobTitle()
                {
                    Title = JobTitle.JobTitles.Middle,
                    Salary = 10000
                },
                new JobTitle()
                {
                    Title = JobTitle.JobTitles.Senior,
                    Salary = 12000
                },
                new JobTitle()
                {
                    Title = JobTitle.JobTitles.TechLead,
                    Salary = 14000
                },
                new JobTitle()
                {
                    Title = JobTitle.JobTitles.TeamLead,
                    Salary = 15000
                },
                 
            });
    }
}