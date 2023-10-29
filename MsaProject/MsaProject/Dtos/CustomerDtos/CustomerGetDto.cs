namespace MsaProject.Dtos.CustomerDtos
{
    public class CustomerGetDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
    }
}
