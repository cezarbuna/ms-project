using System.ComponentModel.DataAnnotations;

namespace MsaProject.Dtos.MenuDtos
{
    public class MenuPostDto
    {
        [Required]
        public Guid RestaurantId { get; set; }
    }
}
