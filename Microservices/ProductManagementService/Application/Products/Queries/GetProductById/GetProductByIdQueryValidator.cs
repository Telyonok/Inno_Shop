using FluentValidation;

namespace ProductManagementService.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(deleteProductCommand => deleteProductCommand.Id).GreaterThanOrEqualTo(0);
        }
    }
}
