using System.ComponentModel.DataAnnotations;

namespace MsaProject.Dtos.MenuItemDto
{
    public class MenuItemPostDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public Guid MenuId { get; set; }
        public string ImageUrl { get; set; }
    }
}
