using ProductManagementService.Application.DTOs;
using MediatR;

namespace ProductManagementService.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<ProductDTO>>
    {
    }
}