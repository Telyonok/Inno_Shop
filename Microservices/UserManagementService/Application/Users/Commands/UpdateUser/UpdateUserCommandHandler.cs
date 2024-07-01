using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserManagementService.Application.Common.Exceptions;
using UserManagementService.Domain.Models;
using UserManagementService.Infrastructure.Data;

namespace UserManagementService.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly UsersDbContext _context;
        private readonly IValidator<UpdateUserCommand> _validator;

        public UpdateUserCommandHandler(UsersDbContext context, IValidator<UpdateUserCommand> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<Unit> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(command);

            var entity = await _context.Users.FirstOrDefaultAsync(product =>
                product.Id == command.Id, cancellationToken);

            if (entity == null) // || entity.UserId != command.UserId)
                throw new EntityNotFoundException(nameof(User), command.Id);

            entity.Name = command.Name;
            entity.PasswordHash = new byte[] { 1 }; //rehash
            entity.Email = command.Email;
            entity.Role = command.Role;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
