using MsaProject.Domain;
using System.ComponentModel.DataAnnotations;

public class RestaurantPostDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int NumberOfTables { get; set; }
    [Required]
    public double Rating { get; set; }
    [Required]
    public int OpeningHour { get; set; }
    [Required]
    public int ClosingHour { get; set; }
}