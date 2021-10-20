using System.Collections.Generic;
using Artsy.Models;
using Artsy.Services;
using Microsoft.AspNetCore.Mvc;

namespace Artsy.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ArtistsController : ControllerBase
  {
    private readonly ArtistsService _cs;
    public ArtistsController(ArtistsService cs)
    {
      _cs = cs;
    }
    [HttpGet]
    public ActionResult<List<Artist>> GetArtists()
    {
      try
      {
        var artists = _cs.Get();
        return Ok(artists);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpGet("{artistId}")]
    public ActionResult<Artist> GetArtistById(int artistId)
    {
      try
      {
        var artist = _cs.Get(artistId);
        return Ok(artist);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpPost]
    public ActionResult<Artist> CreateArtist([FromBody] Artist artistData)
    {
      try
      {
        var artist = _cs.CreateArtist(artistData);
        return Ok(artist);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpPut("{artistId}")]
    public ActionResult<Artist> EditArtist(int artistId, [FromBody] Artist artistData)
    {
      try
      {
        var artist = _cs.Edit(artistId, artistData);
        return Ok(artist);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpDelete("{artistId}")]
    public ActionResult<Artist> DeleteArtist(int artistId)
    {
      try
      {
        var artist = _cs.Delete(artistId);
        return Ok(artist);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }
}