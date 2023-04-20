namespace ParkApi.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    [Required]
    [StringLength(25)]
    public string Name { get; set; }
    [Required]
    public string State { get; set; }
    [Required]
    public bool National { get; set; }
  }
}