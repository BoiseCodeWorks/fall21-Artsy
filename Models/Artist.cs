namespace Artsy.Models
{
  public class Artist
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Era { get; set; }
    public string Country { get; set; }
    public string Type { get; set; }
    public int Skill { get; set; }
    public bool IsAlive { get; set; }
  }
}