namespace ProductManagementService.Application.DTOs
{
    public class GetProductsByFilterDTO
    {
        public string? Title { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool? IsInStock { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
