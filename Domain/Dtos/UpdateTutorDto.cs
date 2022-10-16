using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class UpdateTutorDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Error")]
    public string? FullName { get; set; }
    [Required(ErrorMessage = "Error")]
    public int Experience { get; set; }
    [Required(ErrorMessage = "Error")]
    public string? Image { get; set; }
    [Required(ErrorMessage = "Error")]
    public string? BackgroundImage { get; set; }
    [Required(ErrorMessage = "Error")]
    public string? Position { get; set; }
}
