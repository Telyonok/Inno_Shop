using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagementService.Application.DTOs;
using ProductManagementService.Infrastructure.Data;

namespace ProductManagementService.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDTO>>
    {
        private readonly ProductsDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(ProductsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productsQuery = await _context.Products
                .ProjectTo<ProductDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return productsQuery;
        }
    }
}
