using System.Collections.Generic;
using System.Linq;
using Artsy.Models;
using Artsy.Repositories;

namespace Artsy.Services
{
  public class ArtistsService
  {

    // readonly means this value can only be set during construction
    private readonly ArtistsRepository _ar;

    public ArtistsService(ArtistsRepository ar)
    {
      _ar = ar;
    }

    public Artist CreateArtist(Artist artistData)
    {
      return _ar.Create(artistData);
    }
    public List<Artist> Get()
    {
      return _ar.Get();
    }
    public Artist Get(int artistId)
    {
      var artist = _ar.Get(artistId);
      if (artist == null)
      {
        throw new System.Exception("Invalid Artist Id");
      }
      return artist;
    }
    public Artist Edit(int artistId, Artist artistData)
    {
      var artist = Get(artistId);

      artist.Name = artistData.Name ?? artist.Name;
      artist.Era = artistData.Era ?? artist.Era;
      artist.Country = artistData.Country ?? artist.Country;
      artist.Type = artistData.Type ?? artist.Type;
      artist.Skill = artistData.Skill;
      artist.IsAlive = artistData.IsAlive;
      // something here aka save
      _ar.Edit(artistId, artistData);
      return artist;
    }
    public Artist Delete(int artistId)
    {
      var artist = Get(artistId);
      _ar.Delete(artistId);
      return artist;
    }
  }
}