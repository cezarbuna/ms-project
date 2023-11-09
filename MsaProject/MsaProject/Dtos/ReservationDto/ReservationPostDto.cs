using MsaProject.Domain;

public class ReservationPostDto
{
    public Guid CustomerId { get; set; }
    public Guid TableId { get; set; }
    public DateTime ReservationTime { get; set; }
}