using MsaProject.Domain;

namespace MsaProject.Dtos.MenuDtos
{
    public class MenuGetDto
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        //public Restaurant Restaurant { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
