using Microsoft.EntityFrameworkCore;

namespace ParkApi.Models
{
  public class ParkApiContext : DbContext
  {
    public DbSet<Park> Park { get; set; }

    public ParkApiContext(DbContextOptions<ParkApiContext> options) : base(options)
    {
      
    }
  }
}