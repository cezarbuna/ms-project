using MsaProject.Domain;

public class RestaurantPostDto
{
    public string Name { get; set; }
    public int NumberOfTables { get; set; }
    public Guid MenuId { get; set; }
    public double Rating { get; set; }
    public int OpeningHour { get; set; }
    public int ClosingHour { get; set; }
}