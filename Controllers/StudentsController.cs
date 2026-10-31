using Microsoft.AspNetCore.Mvc;
using WebApiPractice.DTOs;
using WebApiPractice.Services;

namespace WebApiPractice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController(IStudentService service) : ControllerBase
{
    [HttpGet]
    public Task<PagedResult<StudentDto>> GetAll(int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default) =>
        service.GetPagedAsync(pageNumber, pageSize, cancellationToken);

    [HttpGet("{id:int}")]
    public async Task<ActionResult<StudentDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var student = await service.GetByIdAsync(id, cancellationToken);
        return student is null ? NotFound() : Ok(student);
    }

    [HttpPost]
    public async Task<ActionResult<StudentDto>> Create(CreateStudentDto dto, CancellationToken cancellationToken)
    {
        var student = await service.CreateAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<StudentDto>> Update(int id, UpdateStudentDto dto, CancellationToken cancellationToken) =>
        Ok(await service.UpdateAsync(id, dto, cancellationToken));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await service.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
