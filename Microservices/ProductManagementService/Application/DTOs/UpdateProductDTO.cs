namespace ProductManagementService.Application.DTOs
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
