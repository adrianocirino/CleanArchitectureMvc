using AutoMapper;
using CleanArchitectureMvc.Application.DTOs;
using CleanArchitectureMvc.Domain.Entities;

namespace CleanArchitectureMvc.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
