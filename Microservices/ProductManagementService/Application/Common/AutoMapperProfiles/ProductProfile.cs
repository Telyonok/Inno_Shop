using AutoMapper;
using ProductManagementService.Application.DTOs;
using ProductManagementService.Application.Products.Commands.CreateProduct;
using ProductManagementService.Application.Products.Commands.UpdateProduct;
using ProductManagementService.Domain.Models;

namespace ProductManagementService.Application.Common.AutoMapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDTO, CreateProductCommand>();
            CreateMap<UpdateProductDTO, UpdateProductCommand>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
