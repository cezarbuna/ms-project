public class RestaurantGetDto
{
    public string Name { get; set; }
    public int NumberOfTables { get; set; }
    public Guid MenuId { get; set; }
    public Menu Menu { get; set; }
    public ICollection<Table> Tables { get; set; }
    public double Rating { get; set; }
    public int OpeningHour { get; set; }
    public int ClosingHour { get; set; }
}