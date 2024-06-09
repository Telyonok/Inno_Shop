using AutoMapper;
using ProductManagementService.Application.DTOs;
using ProductManagementService.Application.Products.Commands.CreateProduct;
using ProductManagementService.Application.Products.Commands.UpdateProduct;
using ProductManagementService.Application.Products.Queries.GetProductsByFilter;
using ProductManagementService.Domain.Models;

namespace ProductManagementService.Application.Common.AutoMapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDTO, CreateProductCommand>();
            CreateMap<UpdateProductDTO, UpdateProductCommand>();
            CreateMap<GetProductsByFilterDTO, GetProductsByFilterQuery>();
            CreateMap<Product, ProductDTO>();
        }
    }
}