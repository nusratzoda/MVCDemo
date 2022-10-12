using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class UpdateDepartmentDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Plz fill the description")]
    public string Description { get; set; }
}