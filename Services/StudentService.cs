using WebApiPractice.DTOs;
using WebApiPractice.Models;
using WebApiPractice.Repositories;

namespace WebApiPractice.Services;

public class StudentService(IStudentRepository repository) : IStudentService
{
    public async Task<PagedResult<StudentDto>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        ValidatePage(pageNumber, pageSize);
        var (items, totalCount) = await repository.GetPagedAsync(pageNumber, pageSize, cancellationToken);
        return new PagedResult<StudentDto>
        {
            Items = items.Select(Map).ToList(), PageNumber = pageNumber, PageSize = pageSize, TotalCount = totalCount
        };
    }

    public async Task<StudentDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var student = await repository.GetByIdAsync(id, cancellationToken);
        return student is null ? null : Map(student);
    }

    public async Task<StudentDto> CreateAsync(CreateStudentDto dto, CancellationToken cancellationToken)
    {
        if (await repository.EmailExistsAsync(dto.Email, null, cancellationToken)) throw new InvalidOperationException("A student with this email already exists.");
        var student = new Student { Name = dto.Name.Trim(), Email = dto.Email.Trim(), Age = dto.Age, DepartmentId = dto.DepartmentId };
        await repository.AddAsync(student, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return Map(student);
    }

    public async Task<StudentDto> UpdateAsync(int id, UpdateStudentDto dto, CancellationToken cancellationToken)
    {
        var student = await repository.GetByIdAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Student not found.");
        if (await repository.EmailExistsAsync(dto.Email, id, cancellationToken)) throw new InvalidOperationException("A student with this email already exists.");
        student.Name = dto.Name.Trim(); student.Email = dto.Email.Trim(); student.Age = dto.Age; student.DepartmentId = dto.DepartmentId;
        repository.Update(student);
        await repository.SaveChangesAsync(cancellationToken);
        return Map(student);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var student = await repository.GetByIdAsync(id, cancellationToken) ?? throw new KeyNotFoundException("Student not found.");
        repository.Delete(student);
        await repository.SaveChangesAsync(cancellationToken);
    }

    private static StudentDto Map(Student student) => new()
    {
        Id = student.Id, Name = student.Name, Email = student.Email, Age = student.Age,
        DepartmentId = student.DepartmentId, DepartmentName = student.Department?.Name
    };

    private static void ValidatePage(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize is < 1 or > 100) throw new ArgumentOutOfRangeException(nameof(pageSize), "Page number must be positive and page size must be between 1 and 100.");
    }
}
