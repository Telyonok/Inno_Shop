using FluentValidation;

namespace ProductManagementService.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryValidator : AbstractValidator<GetAllProductsQuery>
    {
        public GetAllProductsQueryValidator()
        {
        }
    }
}
