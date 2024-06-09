using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagementService.Application.DTOs;
using ProductManagementService.Infrastructure.Data;

namespace ProductManagementService.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDTO>
    {
        private readonly ProductsDbContext _context;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(ProductsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(product =>
                product.Id == request.Id, cancellationToken);

            if (entity == null) // || entity.UserId != request.UserId)
            {
                throw new Exception(); // NotFoundException(nameof(Product), request.Id);
            }

            return _mapper.Map<ProductDTO>(entity);
        }
    }
}
