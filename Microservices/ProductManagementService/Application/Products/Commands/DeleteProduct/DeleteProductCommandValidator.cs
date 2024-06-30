using FluentValidation;

namespace ProductManagementService.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator() 
        {
            RuleFor(deleteProductCommand => deleteProductCommand.Id).GreaterThanOrEqualTo(0);
        }
    }
}
