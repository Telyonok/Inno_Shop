using FluentValidation;
using MediatR;
using ProductManagementService.Domain.Models;
using ProductManagementService.Infrastructure.Data;

namespace ProductManagementService.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly ProductsDbContext _context;
        private readonly IValidator<CreateProductCommand> _validator;

        public CreateProductCommandHandler(ProductsDbContext context, IValidator<CreateProductCommand> validator)
        {
            _context = context;
            _validator = validator;
        }
        
        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(command);
            
            Product product = new()
            {
                UserId = command.UserId,
                Title = command.Title,
                Description = command.Description,
                Price = command.Price,
                IsInStock = command.IsInStock,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
            };

            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
