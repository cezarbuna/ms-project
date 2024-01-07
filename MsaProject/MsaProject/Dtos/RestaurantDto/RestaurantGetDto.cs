using MsaProject.Domain;

public class RestaurantGetDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int NumberOfTables { get; set; }
    public double Rating { get; set; }
    public int OpeningHour { get; set; }
    public int ClosingHour { get; set; }
    public string ImageUrl { get; set; }
}