using MsaProject.Domain;

namespace MsaProject.Dtos.MenuItemDto
{
    public class MenuItemGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Guid MenuId { get; set; }
    }
}
