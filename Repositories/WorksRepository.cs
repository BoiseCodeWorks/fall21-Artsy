using System.Collections.Generic;
using System.Data;
using System.Linq;
using Artsy.Models;
using Dapper;

namespace Artsy.Repositories
{
  public class WorksRepository
  {

    private readonly IDbConnection _db;

    public WorksRepository(IDbConnection db)
    {
      _db = db;
    }

    public Work Create(Work data)
    {

      var sql = @"
        INSERT INTO works(
          title,
          artistId
        )
        VALUES (
          @Title,
          @ArtistId
        );
        SELECT LAST_INSERT_ID();
      ";
      // idOfTheNewlyCreatedArtist
      var id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }

    internal List<Work> GetByArtistId(int artistId)
    {
      // FUTURE ME PROBLEM include the artist again
      var sql = @"
      SELECT *
      FROM works w
      WHERE w.artistId = @artistId
      ";
      return _db.Query<Work>(sql, new { artistId }).ToList();
    }

    public List<Work> Get()
    {
      var sql = @"
        SELECT 
          w.*, 
          a.id,
          a.name, 
          a.isAlive
        FROM works w
        JOIN artists a
        ON a.id = w.artistId;
      ";
      return _db.Query<Work, LimitedArtist, Work>(sql, (w, a) =>
      {
        w.Artist = a;
        return w;
      }).ToList();
    }
    public Work Get(int id)
    {
      return _db
        .QueryFirstOrDefault<Work>("SELECT * FROM works WHERE id = @id", new { id });
    }

    public Work Edit(int id, Work data)
    {
      data.Id = id;
      var sql = @"
        UPDATE works
        SET
          title = @Title,
          artistId = @ArtistId
        WHERE id = @Id
      ";

      var rowsAffected = _db.Execute(sql, data);

      if (rowsAffected > 1)
      {
        throw new System.Exception("SOMEONE GO TELL THE DB ADMIN WE DONE MESSED UP");
      }
      if (rowsAffected == 0)
      {
        throw new System.Exception("The update failed");
      }
      return data;
    }

    public void Delete(int id)
    {
      var rowsAffected = _db.Execute("DELETE FROM works WHERE id = @id", new { id });

      if (rowsAffected > 1)
      {
        throw new System.Exception("SOMEONE GO TELL THE DB ADMIN WE DONE MESSED UP");
      }
      if (rowsAffected == 0)
      {
        throw new System.Exception("The update failed");
      }
    }
  }
}