using FluentValidation;

namespace ProductManagementService.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator() 
        {
            RuleFor(createProductCommand =>
                createProductCommand.Title).NotEmpty().MaximumLength(100);
            RuleFor(createProductCommand =>
                createProductCommand.Description).NotEmpty().MaximumLength(500);
            RuleFor(createProductCommand =>
                createProductCommand.Price).GreaterThan(0).LessThan(decimal.MaxValue);
        }
    }
}
