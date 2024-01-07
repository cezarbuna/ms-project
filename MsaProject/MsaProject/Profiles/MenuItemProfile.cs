using AutoMapper;
using MsaProject.Domain;
using MsaProject.Dtos.MenuItemDto;

namespace MsaProject.Profiles
{
    public class MenuItemProfile : Profile
    {
        public MenuItemProfile()
        {
            CreateMap<MenuItem, MenuItemGetDto>()
                .ForMember(m => m.Id, opt => opt.MapFrom(d => d.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(d => d.Name))
                .ForMember(m => m.Price, opt => opt.MapFrom(d => d.Price))
                .ForMember(m => m.MenuId, opt => opt.MapFrom(d => d.MenuId))
                .ForMember(m => m.ImageUrl, opt => opt.MapFrom(d => d.ImageUrl));
            CreateMap<MenuItemGetDto, MenuItem>()
                .ForMember(m => m.Id, opt => opt.MapFrom(d => d.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(d => d.Name))
                .ForMember(m => m.Price, opt => opt.MapFrom(d => d.Price))
                .ForMember(m => m.MenuId, opt => opt.MapFrom(d => d.MenuId))
                .ForMember(m => m.ImageUrl, opt => opt.MapFrom(d => d.ImageUrl));
            CreateMap<MenuItemPostDto, MenuItem>()
                .ForMember(m => m.Name, opt => opt.MapFrom(d => d.Name))
                .ForMember(m => m.Price, opt => opt.MapFrom(d => d.Price))
                .ForMember(m => m.MenuId, opt => opt.MapFrom(d => d.MenuId))
                .ForMember(m => m.ImageUrl, opt => opt.MapFrom(d => d.ImageUrl));
            CreateMap<MenuItem, MenuItemPostDto>()
                .ForMember(m => m.Name, opt => opt.MapFrom(d => d.Name))
                .ForMember(m => m.Price, opt => opt.MapFrom(d => d.Price))
                .ForMember(m => m.MenuId, opt => opt.MapFrom(d => d.MenuId))
                .ForMember(m => m.ImageUrl, opt => opt.MapFrom(d => d.ImageUrl));
        }
    }
}
