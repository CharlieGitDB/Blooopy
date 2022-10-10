using System.ComponentModel.DataAnnotations;

namespace Blooopy.Models;
public class Comment
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200, ErrorMessage = "Comment cannot be longer than 200 characters")]
    [MinLength(1, ErrorMessage = "Comment must be at least 1 character")]
    public string? Text { get; set; }
    
    public int BlooopId { get; set; }
    public Blooop? Blooop {get; set; }
}