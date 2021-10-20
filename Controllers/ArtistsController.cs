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
    private readonly ArtistsService _artistsService;
    private readonly WorksService _worksService;
    public ArtistsController(ArtistsService artistsService, WorksService worksService)
    {
      _artistsService = artistsService;
      _worksService = worksService;
    }
    [HttpGet]
    public ActionResult<List<Artist>> GetArtists()
    {
      try
      {
        var artists = _artistsService.Get();
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
        var artist = _artistsService.Get(artistId);
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
        var artist = _artistsService.CreateArtist(artistData);
        return Ok(artist);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpGet("{artistId}/works")]
    public ActionResult<List<Work>> GetArtistWork(int artistId)
    {
      try
      {
        var works = _worksService.GetByArtistId(artistId);
        return Ok(works);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpPost("{artistId}/works")]
    public ActionResult<Work> CreateArtistWork(int artistId, [FromBody] Work workData)
    {
      try
      {
        // Matches route param to the actual data
        workData.ArtistId = artistId;
        var work = _worksService.Create(workData);
        return Ok(work);
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
        var artist = _artistsService.Edit(artistId, artistData);
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
        var artist = _artistsService.Delete(artistId);
        return Ok(artist);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }
}