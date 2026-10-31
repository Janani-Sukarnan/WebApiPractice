using Microsoft.EntityFrameworkCore;
using WebApiPractice.Data;
using WebApiPractice.Models;

namespace WebApiPractice.Repositories;

public class StudentRepository(ApplicationDbContext context) : IStudentRepository
{
    public async Task<(IReadOnlyList<Student> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var query = context.Students.AsNoTracking().Include(student => student.Department).OrderBy(student => student.Name);
        var totalCount = await query.CountAsync(cancellationToken);
        var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        return (items, totalCount);
    }

    public Task<Student?> GetByIdAsync(int id, CancellationToken cancellationToken) =>
        context.Students.Include(student => student.Department).FirstOrDefaultAsync(student => student.Id == id, cancellationToken);

    public Task<bool> EmailExistsAsync(string email, int? excludedId, CancellationToken cancellationToken) =>
        context.Students.AnyAsync(student => student.Email == email && (!excludedId.HasValue || student.Id != excludedId.Value), cancellationToken);

    public Task AddAsync(Student student, CancellationToken cancellationToken) => context.Students.AddAsync(student, cancellationToken).AsTask();

    public void Update(Student student) => context.Students.Update(student);

    public void Delete(Student student) => context.Students.Remove(student);

    public Task SaveChangesAsync(CancellationToken cancellationToken) => context.SaveChangesAsync(cancellationToken);
}
