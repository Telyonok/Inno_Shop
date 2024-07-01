using FluentValidation;
using MediatR;
using UserManagementService.Application.Common.Exceptions;
using UserManagementService.Domain.Models;
using UserManagementService.Infrastructure.Data;

namespace UserManagementService.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly UsersDbContext _context;
        private readonly IValidator<DeleteUserCommand> _validator;

        public DeleteUserCommandHandler(UsersDbContext context, IValidator<DeleteUserCommand> validator)
        {
            _context = context;
            _validator = validator;
        }

    public async Task<Unit> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(command);

            var entity = await _context.Users
                .FindAsync([command.Id], cancellationToken);

            if (entity == null) // entity.UserId != command.UserId)
                throw new EntityNotFoundException(nameof(User), command.Id);

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
