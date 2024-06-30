using FluentValidation;

namespace ProductManagementService.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator() 
        {
            RuleFor(updateProductCommand =>
                updateProductCommand.Title).NotEmpty().MaximumLength(100);
            RuleFor(updateProductCommand =>
                updateProductCommand.Description).NotEmpty().MaximumLength(500);
            RuleFor(updateProductCommand =>
                updateProductCommand.Price).GreaterThan(0).LessThan(decimal.MaxValue);
        }
    }
}
