namespace Artsy.Models
{
  public class Work
  {
    public int Id { get; set; }
    public int ArtistId { get; set; }
    public string Title { get; set; }

    public LimitedArtist Artist { get; set; }
  }

}