using System.ComponentModel.DataAnnotations;

namespace WebApiPractice.DTOs;

public class CreateStudentDto
{
    [Required, MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [Required, EmailAddress, MaxLength(255)]
    public string Email { get; set; } = string.Empty;

    [Range(1, 150)]
    public int Age { get; set; }

    public int? DepartmentId { get; set; }
}
