using AutoMapper;
using MsaProject.Domain;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MsaProject.Profiles
{
    public class TableProfile : Profile
    {
        public TableProfile()
        {
            CreateMap<Table, TableGetDto>()
                .ForMember(m => m.Id, opt => opt.MapFrom(d => d.Id))
                .ForMember(m => m.RestaurantId, opt => opt.MapFrom(d => d.RestaurantId))
                .ForMember(m => m.Restaurant, opt => opt.MapFrom(d => d.Restaurant))
                .ForMember(m => m.IsBooked, opt => opt.MapFrom(d => d.IsBooked))
                .ForMember(m => m.NumberOfSeats, opt => opt.MapFrom(d => d.NumberOfSeats));
            CreateMap<TableGetDto, Table>()
                .ForMember(m => m.Id, opt => opt.MapFrom(d => d.Id))
                .ForMember(m => m.RestaurantId, opt => opt.MapFrom(d => d.RestaurantId))
                .ForMember(m => m.Restaurant, opt => opt.MapFrom(d => d.Restaurant))
                .ForMember(m => m.IsBooked, opt => opt.MapFrom(d => d.IsBooked))
                .ForMember(m => m.NumberOfSeats, opt => opt.MapFrom(d => d.NumberOfSeats));
            CreateMap<Table, TablePostDto>()
                .ForMember(m => m.RestaurantId, opt => opt.MapFrom(d => d.RestaurantId))
                .ForMember(m => m.IsBooked, opt => opt.MapFrom(d => d.IsBooked))
                .ForMember(m => m.NumberOfSeats, opt => opt.MapFrom(d => d.NumberOfSeats));
            CreateMap<TablePostDto, Table>()
                .ForMember(m => m.RestaurantId, opt => opt.MapFrom(d => d.RestaurantId))
                .ForMember(m => m.IsBooked, opt => opt.MapFrom(d => d.IsBooked))
                .ForMember(m => m.NumberOfSeats, opt => opt.MapFrom(d => d.NumberOfSeats));
        }
    }
}
