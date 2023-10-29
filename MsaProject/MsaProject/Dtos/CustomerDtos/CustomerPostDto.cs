using System.ComponentModel.DataAnnotations;

namespace MsaProject.Dtos.CustomerDtos
{
    public class CustomerPostDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
