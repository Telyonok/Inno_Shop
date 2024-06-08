using FluentValidation;
using MediatR;
using ProductManagementService.Application.Products.Commands.CreateProduct;
using ProductManagementService.Infrastructure.Data;

namespace ProductManagementService.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly ProductsDbContext _context;
        private readonly IValidator<DeleteProductCommand> _validator;

        public DeleteProductCommandHandler(ProductsDbContext context, IValidator<DeleteProductCommand> validator)
        {
            _context = context;
            _validator = validator;
        }

    public async Task<Unit> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(command);

            var entity = await _context.Products
                .FindAsync([command.Id], cancellationToken);

            if (entity == null) // entity.UserId != command.UserId)
            {
                throw new Exception(); // NotFoundException(nameof(Product), command.Id);
            }

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
