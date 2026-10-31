using WebApiPractice.Models;

namespace WebApiPractice.Repositories;

public interface IStudentRepository
{
    Task<(IReadOnlyList<Student> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<Student?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<bool> EmailExistsAsync(string email, int? excludedId, CancellationToken cancellationToken);
    Task AddAsync(Student student, CancellationToken cancellationToken);
    void Update(Student student);
    void Delete(Student student);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
