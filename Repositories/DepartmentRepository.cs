/*using Microsoft.EntityFrameworkCore;
using WebApiPractice.Data;
using WebApiPractice.Models;

namespace WebApiPractice.Repositories;

public class DepartmentRepository(ApplicationDbContext context) : IDepartmentRepository
{
    public async Task<(IReadOnlyList<Department> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var query = context.Departments.AsNoTracking().OrderBy(department => department.Name);
        var totalCount = await query.CountAsync(cancellationToken);
        var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        return (items, totalCount);
    }

    public Task<Department?> GetByIdAsync(int id, CancellationToken cancellationToken) =>
        context.Departments.Include(department => department.Students).FirstOrDefaultAsync(department => department.Id == id, cancellationToken);

    public Task AddAsync(Department department, CancellationToken cancellationToken) => context.Departments.AddAsync(department, cancellationToken).AsTask();

    public void Update(Department department) => context.Departments.Update(department);

    public void Delete(Department department) => context.Departments.Remove(department);

    public Task<bool> ExistsAsync(int id, CancellationToken cancellationToken) => context.Departments.AnyAsync(department => department.Id == id, cancellationToken);

    public Task SaveChangesAsync(CancellationToken cancellationToken) => context.SaveChangesAsync(cancellationToken);
}
*/