using MsaProject.Domain;

public class TablePostDto
{
    public Guid RestaurantId { get; set; }

    public int NumberOfSeats { get; set; }
    public bool IsBooked { get; set; }
}