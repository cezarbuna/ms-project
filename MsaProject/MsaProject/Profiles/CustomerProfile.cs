using AutoMapper;
using MsaProject.Domain;
using MsaProject.Dtos.CustomerDtos;

namespace MsaProject.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerGetDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(d => d.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(d => d.Password, opt => opt.MapFrom(c => c.Password))
                .ForMember(d => d.FullName, opt => opt.MapFrom(c => c.FullName))
                .ForMember(d => d.Age, opt => opt.MapFrom(c => c.Age))
                .ForMember(d => d.Username, opt => opt.MapFrom(c => c.Username));

            CreateMap<Customer, CustomerPostDto>()
                .ForMember(d => d.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(d => d.Password, opt => opt.MapFrom(c => c.Password))
                .ForMember(d => d.FullName, opt => opt.MapFrom(c => c.FullName))
                .ForMember(d => d.Age, opt => opt.MapFrom(c => c.Age))
                .ForMember(d => d.Username, opt => opt.MapFrom(c => c.Username));
            CreateMap<CustomerGetDto, Customer>()
                .ForMember(d => d.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(d => d.Password, opt => opt.MapFrom(c => c.Password))
                .ForMember(d => d.FullName, opt => opt.MapFrom(c => c.FullName))
                .ForMember(d => d.Age, opt => opt.MapFrom(c => c.Age))
                .ForMember(d => d.Username, opt => opt.MapFrom(c => c.Username));
            CreateMap<CustomerPostDto, Customer>()
                .ForMember(d => d.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(d => d.Password, opt => opt.MapFrom(c => c.Password))
                .ForMember(d => d.FullName, opt => opt.MapFrom(c => c.FullName))
                .ForMember(d => d.Age, opt => opt.MapFrom(c => c.Age))
                .ForMember(d => d.Username, opt => opt.MapFrom(c => c.Username));
        }
    }
}
