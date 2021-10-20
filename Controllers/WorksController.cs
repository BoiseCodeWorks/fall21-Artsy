using System.Collections.Generic;
using Artsy.Models;
using Artsy.Services;
using Microsoft.AspNetCore.Mvc;

namespace Artsy.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WorksController : ControllerBase
  {

    private readonly WorksService _ws;

    public WorksController(WorksService ws)
    {
      _ws = ws;
    }

    [HttpGet]
    public ActionResult<List<Work>> GetWorks()
    {
      try
      {
        var works = _ws.Get();
        return Ok(works);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpPost]
    public ActionResult<Work> CreateWorks([FromBody] Work workData)
    {
      try
      {
        var work = _ws.Create(workData);
        return Ok(work);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }
}