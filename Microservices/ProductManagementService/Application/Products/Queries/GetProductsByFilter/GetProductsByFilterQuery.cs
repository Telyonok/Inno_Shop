using MediatR;
using ProductManagementService.Application.DTOs;

namespace ProductManagementService.Application.Products.Queries.GetProductsByFilter
{
    public class GetProductsByFilterQuery : IRequest<List<ProductDTO>>
    {
        public string? Title { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool? IsInStock { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
