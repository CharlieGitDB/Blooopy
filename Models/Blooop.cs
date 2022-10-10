using System.ComponentModel.DataAnnotations;


namespace Blooopy.Models;

public class Blooop
{
    
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(400, ErrorMessage = "Blooop cannot be longer than 400 characters")]
    [MinLength(1, ErrorMessage = "Blooop must at least be 1 character")]
    public string? Text { get; set; }

    [Required]
    public long ShareCount { get; set; } = 0;

    public List<Comment>? Comments { get; set; } 
}