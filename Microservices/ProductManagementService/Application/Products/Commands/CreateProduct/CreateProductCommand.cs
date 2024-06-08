using MediatR;

namespace ProductManagementService.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsInStock { get; set; }
    }
}
