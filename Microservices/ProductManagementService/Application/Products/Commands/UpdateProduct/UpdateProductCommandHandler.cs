using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagementService.Application.Products.Commands.CreateProduct;
using ProductManagementService.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;

namespace ProductManagementService.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly ProductsDbContext _context;
        private readonly IValidator<UpdateProductCommand> _validator;

        public UpdateProductCommandHandler(ProductsDbContext context, IValidator<UpdateProductCommand> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<Unit> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(command);

            var entity = await _context.Products.FirstOrDefaultAsync(product =>
                product.Id == command.Id, cancellationToken);

            if (entity == null) // || entity.UserId != command.UserId)
            {
                throw new Exception(); // NotFoundException(nameof(Product), command.Id);
            }

            entity.Title = command.Title;
            entity.Description = command.Description;
            entity.Price = command.Price;
            entity.IsInStock = command.IsInStock;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
