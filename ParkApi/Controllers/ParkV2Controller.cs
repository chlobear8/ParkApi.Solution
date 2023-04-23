using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkApi.Models;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace ParkApi.Controllers
{
  [ApiController]
  [Route("api/{v:apiVersion}/[controller]")]
  [ApiVersion("2.0")]//new version
  
  public class ParkV2Controller : ControllerBase
  {
    private readonly ParkApiContext _db;

    public ParkV2Controller(ParkApiContext db)
    {
      _db = db;
    }

    [HttpGet("version")]
    public IActionResult GetVersion( ApiVersion apiVersion ) => Ok( new { Controller = GetType().Name, Version = apiVersion.ToString() });

    // [HttpGet, MapToApiVersion( "2.0" )]
    // public string GetV2( ApiVersion apiVersion) => "Version" + apiVersion;

    // [HttpGet( "{id:int}" )]
    // public IActionResult Get( int id, ApiVersion apiVersion ) => Ok( new { Controller = GetType().Name, Id = id });

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string name, string state, bool? national)
    {
      IQueryable<Park> query = _db.Park.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (state != null)
      {
        query = query.Where(entry => entry.State == state);
      }

      if (national != null)
      {
        query = query.Where(entry => entry.National == national);
      }

      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      Park park = await _db.Park.FindAsync(id);

      if (park == null)
      {
        return NotFound();
      }

      return park;
    }

    // [HttpPost]
    // public IActionResult Post( ApiVersion apiVersion) => CreatedAtAction( nameof( Get ), new { id = 42 }, null );

    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
      _db.Park.Add(park);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }

      _db.Park.Update(park);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool ParkExists(int id)
    {
      return _db.Park.Any(e => e.ParkId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      Park park = await _db.Park.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }

      _db.Park.Remove(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}