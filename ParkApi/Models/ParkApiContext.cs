using Microsoft.EntityFrameworkCore;

namespace ParkApi.Models
{
  public class ParkApiContext : DbContext
  {
    public DbSet<Park> Park { get; set; }

    public ParkApiContext(DbContextOptions<ParkApiContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>()
              .HasData(
                new Park { ParkId = 1, Name = "Crater Lake", State = "Oregon", National = True},
                new Park { ParkId = 2, Name = "Ainsworth", State = "Oregon", National = False},
                new Park { ParkId = 3, Name = "Bates", State = "Oregon", National = False},
                new Park { ParkId = 4, Name = "Angel Island", State = "California", National = Flase},
                new Park { ParkId = 5, Name = "Van Damme", State = "California", National = False},
                new Park { ParkId = 6, Name = "Yosemite", State = "California", National = True},
                new Park { ParkId = 7, Name = "Joshua Tree", State = "California", National = True},
                new Park { ParkId = 8, Name = "Big Bend", State = "Texas", National = True},
                new Park { ParkId = 9, Name = "Big Spring", State = "Texas", National = False}
              );
    }
  }
}