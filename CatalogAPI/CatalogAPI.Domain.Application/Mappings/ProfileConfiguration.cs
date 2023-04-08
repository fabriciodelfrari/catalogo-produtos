using AutoMapper;
using CatalogAPI.Domain.Application.DTOs;
using CatalogAPI.Domain.Model.Entities;

namespace CatalogAPI.Domain.Application.Mappings
{
    public class ProfileConfiguration : Profile
    {
        public ProfileConfiguration()
        {
            #region DTOs
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            #endregion
        }
    }
}
