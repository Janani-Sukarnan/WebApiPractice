using WebApiPractice.DTOs;

namespace WebApiPractice.Services;

public interface IStudentService
{
    Task<PagedResult<StudentDto>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<StudentDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<StudentDto> CreateAsync(CreateStudentDto dto, CancellationToken cancellationToken);
    Task<StudentDto> UpdateAsync(int id, UpdateStudentDto dto, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}
