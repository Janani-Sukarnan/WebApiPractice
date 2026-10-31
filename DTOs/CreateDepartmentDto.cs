using System.ComponentModel.DataAnnotations;

namespace WebApiPractice.DTOs;

public class CreateDepartmentDto
{
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
}
