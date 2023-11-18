using MsaProject.Domain;

public class OwnerGetDo
{
    public Guid Id { get; set; }
    public string OwnerId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
}