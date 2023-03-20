using AutoMapper;
using CatalogAPI.Domain.Application.DTOs;
using CatalogAPI.Domain.Entities;


namespace CatalogAPI.Domain.Application.Mappings
{
    public class ProfileConfiguration : Profile
    {
        public ProfileConfiguration()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}
