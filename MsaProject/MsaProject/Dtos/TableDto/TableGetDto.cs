using MsaProject.Domain;

public class TableGetDto
{
    public Guid Id { get; set; }
    public Guid RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public int NumberOfSeats { get; set; }
    public bool IsBooked { get; set; }

}