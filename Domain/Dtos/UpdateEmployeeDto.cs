using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class UpdateEmployeeDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Error")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Error")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Error")]
    public string? Phone { get; set; }
    [Required(ErrorMessage = "Error")]
    public int DepartmentId { get; set; }
}