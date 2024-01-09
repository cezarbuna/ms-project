using MsaProject.Domain;
using System.ComponentModel.DataAnnotations;

public class ReservationPostDto
{
    [Required]
    public Guid CustomerId { get; set; }
    [Required]
    public Guid TableId { get; set; }
    [Required]
    public DateTime ReservationDate { get; set; }
}