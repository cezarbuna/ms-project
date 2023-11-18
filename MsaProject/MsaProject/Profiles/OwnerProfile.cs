using AutoMapper;
using MsaProject.Domain;
using MsaProject.Dtos.OwnerDto;

namespace MsaProject.Profiles
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            CreateMap<Owner, OwnerGetDo>()
                .ForMember(d => d.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(d => d.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(d => d.Password, opt => opt.MapFrom(c => c.Password))
                .ForMember(d => d.FullName, opt => opt.MapFrom(c => c.FullName));
            CreateMap<OwnerGetDo, Owner>()
                .ForMember(d => d.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(d => d.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(d => d.Password, opt => opt.MapFrom(c => c.Password))
                .ForMember(d => d.FullName, opt => opt.MapFrom(c => c.FullName));
            CreateMap<Owner, OwnerPostDto>()
                .ForMember(d => d.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(d => d.Password, opt => opt.MapFrom(c => c.Password))
                .ForMember(d => d.FullName, opt => opt.MapFrom(c => c.FullName));
            CreateMap<OwnerPostDto, Owner>()
                .ForMember(d => d.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(d => d.Password, opt => opt.MapFrom(c => c.Password))
                .ForMember(d => d.FullName, opt => opt.MapFrom(c => c.FullName));
        }
    }
}
