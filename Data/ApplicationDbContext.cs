using Microsoft.EntityFrameworkCore;
using WebApiPractice.Models;

namespace WebApiPractice.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Department> Departments => Set<Department>();

    public DbSet<Student> Students => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(department => department.Name)
                .HasMaxLength(100)
                .IsRequired();
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(student => student.Name)
                .HasMaxLength(150)
                .IsRequired();
            entity.Property(student => student.Email)
                .HasMaxLength(255)
                .IsRequired();
            entity.HasIndex(student => student.Email).IsUnique();
            entity.HasOne(student => student.Department)
                .WithMany(department => department.Students)
                .HasForeignKey(student => student.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);
        });
    }
}
