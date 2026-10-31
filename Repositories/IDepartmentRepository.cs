using WebApiPractice.Models;

namespace WebApiPractice.Repositories;

public interface IDepartmentRepository
{
    Task<(IReadOnlyList<Department> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<Department?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task AddAsync(Department department, CancellationToken cancellationToken);
    void Update(Department department);
    void Delete(Department department);
    Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
