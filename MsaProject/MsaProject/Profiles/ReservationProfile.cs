using AutoMapper;
using MsaProject.Domain;

namespace MsaProject.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationGetDto>()
                .ForMember(m => m.Id, opt => opt.MapFrom(d => d.Id))
                .ForMember(m => m.CustomerId, opt => opt.MapFrom(d => d.CustomerId))
                .ForMember(m => m.Customer, opt => opt.MapFrom(d => d.Customer))
                .ForMember(m => m.TableId, opt => opt.MapFrom(d => d.TableId))
                .ForMember(m => m.Table, opt => opt.MapFrom(d => d.Table))
                .ForMember(m => m.ReservationDate, opt => opt.MapFrom(d => d.ReservationDate));
            CreateMap<ReservationGetDto, Reservation>()
                .ForMember(m => m.Id, opt => opt.MapFrom(d => d.Id))
                .ForMember(m => m.CustomerId, opt => opt.MapFrom(d => d.CustomerId))
                .ForMember(m => m.Customer, opt => opt.MapFrom(d => d.Customer))
                .ForMember(m => m.TableId, opt => opt.MapFrom(d => d.TableId))
                .ForMember(m => m.Table, opt => opt.MapFrom(d => d.Table))
                .ForMember(m => m.ReservationDate, opt => opt.MapFrom(d => d.ReservationDate));
            CreateMap<Reservation, ReservationPostDto>()
                .ForMember(m => m.CustomerId, opt => opt.MapFrom(d => d.CustomerId))
                .ForMember(m => m.TableId, opt => opt.MapFrom(d => d.Table))
                .ForMember(m => m.ReservationDate, opt => opt.MapFrom(d => d.ReservationDate));
            CreateMap<ReservationPostDto, Reservation>()
                .ForMember(m => m.CustomerId, opt => opt.MapFrom(d => d.CustomerId))
                .ForMember(m => m.TableId, opt => opt.MapFrom(d => d.TableId))
                .ForMember(m => m.ReservationDate, opt => opt.MapFrom(d => d.ReservationDate));
        }
    }
}
