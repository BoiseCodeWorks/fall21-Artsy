using System.Collections.Generic;
using System.Data;
using System.Linq;
using Artsy.Models;
using Dapper;

namespace Artsy.Repositories
{
  public class ArtistsRepository
  {

    private readonly IDbConnection _db;

    public ArtistsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Artist Create(Artist artistData)
    {

      var sql = @"
        INSERT INTO artists(
          name,
          skill,
          country,
          type,
          era
        )
        VALUES (
          @Name,
          @Skill,
          @Country,
          @Type,
          @Era
        );
        SELECT LAST_INSERT_ID();
      ";
      // idOfTheNewlyCreatedArtist
      var id = _db.ExecuteScalar<int>(sql, artistData);
      artistData.Id = id;
      return artistData;
    }

    public List<Artist> Get()
    {
      return _db.Query<Artist>("SELECT * FROM artists").ToList();
    }
    public Artist Get(int id)
    {
      return _db
        .QueryFirstOrDefault<Artist>("SELECT * FROM artists WHERE id = @id", new { id });
    }

    public Artist Edit(int id, Artist artistData)
    {
      artistData.Id = id;
      var sql = @"
        UPDATE artists
        SET
          name = @Name,
          skill = @Skill,
          country = @Country,
          era = @Era,
          type = @Type,
          isAlive = @IsAlive
        WHERE id = @Id
      ";

      var rowsAffected = _db.Execute(sql, artistData);

      if (rowsAffected > 1)
      {
        throw new System.Exception("SOMEONE GO TELL THE DB ADMIN WE DONE MESSED UP");
      }
      if (rowsAffected == 0)
      {
        throw new System.Exception("The update failed");
      }
      return artistData;
    }

    public void Delete(int id)
    {
      var rowsAffected = _db.Execute("DELETE FROM artists WHERE id = @id", new { id });

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