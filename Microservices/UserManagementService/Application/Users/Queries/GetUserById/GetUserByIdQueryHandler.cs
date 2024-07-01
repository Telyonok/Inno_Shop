using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserManagementService.Application.Common.Exceptions;
using UserManagementService.Application.DTOs;
using UserManagementService.Domain.Models;
using UserManagementService.Infrastructure.Data;

namespace UserManagementService.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly UsersDbContext _context;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(UsersDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(product =>
                product.Id == request.Id, cancellationToken);

            if (entity == null) // || entity.UserId != request.UserId)
                throw new EntityNotFoundException(nameof(User), request.Id);

            return _mapper.Map<UserDTO>(entity);
        }
    }
}
