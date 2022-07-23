using AutoMapper;
using CleanArchitectureMvc.Application.DTOs;
using CleanArchitectureMvc.Application.Products.Commands;

namespace CleanArchitectureMvc.Application.Mappings
{
    public class DtoToCommandMappingProfile : Profile
    {
        public DtoToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
        }
    }
}
