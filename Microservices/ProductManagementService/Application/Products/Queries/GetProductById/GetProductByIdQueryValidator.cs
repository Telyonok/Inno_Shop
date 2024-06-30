using FluentValidation;

namespace ProductManagementService.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(getProductByIdQuery => getProductByIdQuery.Id).GreaterThanOrEqualTo(0);
        }
    }
}
