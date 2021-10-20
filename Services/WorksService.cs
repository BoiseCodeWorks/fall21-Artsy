using System;
using System.Collections.Generic;
using Artsy.Models;
using Artsy.Repositories;

namespace Artsy.Services
{
  public class WorksService
  {

    private readonly WorksRepository _wr;
    private readonly ArtistsService _as;

    public WorksService(WorksRepository wr, ArtistsService a)
    {
      _wr = wr;
      _as = a;
    }

    public Work Create(Work workData)
    {
      return _wr.Create(workData);
    }

    public List<Work> Get()
    {
      return _wr.Get();
    }

    public Work Get(int id)
    {
      return _wr.Get(id);
    }
    public List<Work> GetByArtistId(int artistId)
    {
      var artist = _as.Get(artistId);
      return _wr.GetByArtistId(artistId);
    }
  }
}