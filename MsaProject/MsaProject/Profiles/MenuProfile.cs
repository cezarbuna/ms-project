using AutoMapper;
using MsaProject.Domain;
using MsaProject.Dtos.MenuDtos;
using MsaProject.Dtos.MenuItemDto;

namespace MsaProject.Profiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<Menu, MenuGetDto>()
                .ForMember(m => m.Id, opt => opt.MapFrom(d => d.Id))
                .ForMember(m => m.RestaurantId, opt => opt.MapFrom(d => d.RestaurantId));
            CreateMap<MenuGetDto, Menu>()
                .ForMember(m => m.Id, opt => opt.MapFrom(d => d.Id))
                .ForMember(m => m.RestaurantId, opt => opt.MapFrom(d => d.RestaurantId));
            CreateMap<Menu, MenuPostDto>()
                .ForMember(m => m.RestaurantId, opt => opt.MapFrom(d => d.RestaurantId));
            CreateMap<MenuPostDto, Menu>()
                .ForMember(m => m.RestaurantId, opt => opt.MapFrom(d => d.RestaurantId));
        }
    }
}
