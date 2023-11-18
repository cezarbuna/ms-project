using MsaProject.Domain;

public class ReservationGetDto
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public Guid TableId { get; set; }
    public Table Table { get; set; }
    public DateTime ReservationTime { get; set; }
}