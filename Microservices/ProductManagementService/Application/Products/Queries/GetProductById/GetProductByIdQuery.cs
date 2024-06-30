using ProductManagementService.Application.DTOs;
using MediatR;

namespace ProductManagementService.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDTO>
    {
        public int Id { get; set; }
    }
}