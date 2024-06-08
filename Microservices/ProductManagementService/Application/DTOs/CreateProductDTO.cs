namespace ProductManagementService.Application.DTOs
{
    public class CreateProductDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsInStock { get; set; }
    }
}
