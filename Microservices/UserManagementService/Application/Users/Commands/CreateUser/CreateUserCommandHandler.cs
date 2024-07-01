using FluentValidation;
using MediatR;
using UserManagementService.Domain.Models;
using UserManagementService.Infrastructure.Data;

namespace UserManagementService.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly UsersDbContext _context;
        private readonly IValidator<CreateUserCommand> _validator;

        public CreateUserCommandHandler(UsersDbContext context, IValidator<CreateUserCommand> validator)
        {
            _context = context;
            _validator = validator;
        }
        
        public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(command);

            User user = new()
            {
                Name = command.Name,
                Email = command.Email,
                PasswordHash = new byte[] {1,0,1}, // Hash
                Role = command.Role
            };

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
