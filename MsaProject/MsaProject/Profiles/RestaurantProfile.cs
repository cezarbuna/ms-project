using MsaProject.Domain;
using AutoMapper;

namespace MsaProject.Profiles
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantGetDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(d => d.NumberOfTables, opt => opt.MapFrom(c => c.NumberOfTables))
                .ForMember(d => d.Name, opt => opt.MapFrom(c => c.Name))
                .ForMember(d => d.OpeningHour, opt => opt.MapFrom(c => c.OpeningHour))
                .ForMember(d => d.ClosingHour, opt => opt.MapFrom(c => c.ClosingHour))
                .ForMember(d => d.Rating, opt => opt.MapFrom(c => c.Rating));

            CreateMap<RestaurantGetDto, Restaurant>()
                .ForMember(d => d.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(d => d.NumberOfTables, opt => opt.MapFrom(c => c.NumberOfTables))
                .ForMember(d => d.Name, opt => opt.MapFrom(c => c.Name))
                .ForMember(d => d.OpeningHour, opt => opt.MapFrom(c => c.OpeningHour))
                .ForMember(d => d.ClosingHour, opt => opt.MapFrom(c => c.ClosingHour))
                .ForMember(d => d.Rating, opt => opt.MapFrom(c => c.Rating));

            CreateMap<Restaurant, RestaurantPostDto>()
                .ForMember(d => d.NumberOfTables, opt => opt.MapFrom(c => c.NumberOfTables))
                .ForMember(d => d.Name, opt => opt.MapFrom(c => c.Name))
                .ForMember(d => d.OpeningHour, opt => opt.MapFrom(c => c.OpeningHour))
                .ForMember(d => d.ClosingHour, opt => opt.MapFrom(c => c.ClosingHour))
                .ForMember(d => d.Rating, opt => opt.MapFrom(c => c.Rating));

            CreateMap<RestaurantPostDto, Restaurant>()
                .ForMember(d => d.NumberOfTables, opt => opt.MapFrom(c => c.NumberOfTables))
                .ForMember(d => d.Name, opt => opt.MapFrom(c => c.Name))
                .ForMember(d => d.OpeningHour, opt => opt.MapFrom(c => c.OpeningHour))
                .ForMember(d => d.ClosingHour, opt => opt.MapFrom(c => c.ClosingHour))
                .ForMember(d => d.Rating, opt => opt.MapFrom(c => c.Rating));
        }
    }
}
