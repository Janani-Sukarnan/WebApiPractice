using Microsoft.AspNetCore.Mvc;
using WebApiPractice.DTOs;
using WebApiPractice.Services;

namespace WebApiPractice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentsController(IDepartmentService service) : ControllerBase
{
    [HttpGet]
    public Task<PagedResult<DepartmentDto>> GetAll(int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default) =>
        service.GetPagedAsync(pageNumber, pageSize, cancellationToken);

    [HttpGet("{id:int}")]
    public async Task<ActionResult<DepartmentDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var department = await service.GetByIdAsync(id, cancellationToken);
        return department is null ? NotFound() : Ok(department);
    }

    [HttpPost]
    public async Task<ActionResult<DepartmentDto>> Create(CreateDepartmentDto dto, CancellationToken cancellationToken)
    {
        var department = await service.CreateAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<DepartmentDto>> Update(int id, CreateDepartmentDto dto, CancellationToken cancellationToken) =>
        Ok(await service.UpdateAsync(id, dto, cancellationToken));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await service.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
