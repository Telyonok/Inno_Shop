using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagementService.Application.DTOs;
using ProductManagementService.Domain.Models;
using ProductManagementService.Infrastructure.Data;

namespace ProductManagementService.Application.Products.Queries.GetProductsByFilter
{
    public class GetProductsByFilterQueryHandler : IRequestHandler<GetProductsByFilterQuery, List<ProductDTO>>
    {
        private readonly ProductsDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsByFilterQueryHandler(ProductsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> Handle(GetProductsByFilterQuery request, CancellationToken cancellationToken)
        {
            var productsQuery = _context.Products.AsQueryable();

            productsQuery = ApplyFilters(productsQuery, request);

            return await productsQuery.ProjectTo<ProductDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        private IQueryable<Product> ApplyFilters(IQueryable<Product> query, GetProductsByFilterQuery request)
        {
            if (request.Title != null)
                query = query.Where(p => p.Title.Contains(request.Title));

            if (request.MinPrice != null)
                query = query.Where(p => p.Price >= request.MinPrice);

            if (request.MaxPrice != null)
                query = query.Where(p => p.Price <= request.MaxPrice);

            if (request.IsInStock != null)
                query = query.Where(p => p.IsInStock == request.IsInStock);

            if (request.CreatedAt != null)
                query = query.Where(p => p.CreatedAt >= request.CreatedAt);

            return query;
        }
    }
}
