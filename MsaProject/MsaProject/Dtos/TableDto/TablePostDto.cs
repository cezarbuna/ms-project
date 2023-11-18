using MsaProject.Domain;
using System.ComponentModel.DataAnnotations;

public class TablePostDto
{
    [Required]
    public Guid RestaurantId { get; set; }
    [Required]
    public int NumberOfSeats { get; set; }
    [Required]
    public bool IsBooked { get; set; }
}