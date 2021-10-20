using System.ComponentModel.DataAnnotations;

namespace Artsy.Models
{
  public class Artist
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Era { get; set; }
    [Required]
    public string Country { get; set; }
    [Required]
    public string Type { get; set; }
    [Required]
    public int Skill { get; set; }
    public bool IsAlive { get; set; }
  }

}