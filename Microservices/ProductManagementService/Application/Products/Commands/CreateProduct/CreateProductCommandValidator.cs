using FluentValidation;

namespace ProductManagementService.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator() 
        { 
            RuleFor(createProductCommand =>
                createProductCommand.Title).NotEmpty().MaximumLength(100);
            RuleFor(createProductCommand =>
                createProductCommand.Description).MaximumLength(500);
            RuleFor(createProductCommand =>
                createProductCommand.Price).GreaterThan(0).LessThan(decimal.MaxValue);
        }
    }
}
