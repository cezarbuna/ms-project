using MsaProject.Domain;

public class TableGetDto
{

    public Guid RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public int NumberOfSeats { get; set; }

}