using WebApiPractice.DTOs;

namespace WebApiPractice.Services;

public interface IDepartmentService
{
    Task<PagedResult<DepartmentDto>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<DepartmentDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<DepartmentDto> CreateAsync(CreateDepartmentDto dto, CancellationToken cancellationToken);
    Task<DepartmentDto> UpdateAsync(int id, CreateDepartmentDto dto, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}
