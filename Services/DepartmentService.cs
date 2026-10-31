/*using WebApiPractice.DTOs;
using WebApiPractice.Models;
using WebApiPractice.Repositories;

namespace WebApiPractice.Services;

public class DepartmentService(IDepartmentRepository repository) : IDepartmentService
{
    public async Task<PagedResult<DepartmentDto>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        ValidatePage(pageNumber, pageSize);
        var (items, totalCount) = await repository.GetPagedAsync(pageNumber, pageSize, cancellationToken);
        return new PagedResult<DepartmentDto>
        {
            Items = items.Select(Map).ToList(), PageNumber = pageNumber, PageSize = pageSize, TotalCount = totalCount
        };
    }

    public async Task<DepartmentDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var department = await repository.GetByIdAsync(id, cancellationToken);
        return department is null ? null : Map(department);
    }

    public async Task<DepartmentDto> CreateAsync(CreateDepartmentDto dto, CancellationToken cancellationToken)
    {
        var department = new Department { Name = dto.Name.Trim() };
        await repository.AddAsync(department, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return Map(department);
    }

    public async Task<DepartmentDto> UpdateAsync(int id, CreateDepartmentDto dto, CancellationToken cancellationToken)
    {
        var department = await repository.GetByIdAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Department not found.");
        department.Name = dto.Name.Trim();
        repository.Update(department);
        await repository.SaveChangesAsync(cancellationToken);
        return Map(department);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var department = await repository.GetByIdAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Department not found.");
        repository.Delete(department);
        await repository.SaveChangesAsync(cancellationToken);
    }

    private static DepartmentDto Map(Department department) => new()
    {
        Id = department.Id, Name = department.Name, StudentCount = department.Students.Count
    };

    private static void ValidatePage(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize is < 1 or > 100) throw new ArgumentOutOfRangeException(nameof(pageSize), "Page number must be positive and page size must be between 1 and 100.");
    }
}
*/