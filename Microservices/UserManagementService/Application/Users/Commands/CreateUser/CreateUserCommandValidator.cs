using FluentValidation;

namespace UserManagementService.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator() 
        { 
            RuleFor(createUserCommand =>
                createUserCommand.Name).NotEmpty().MaximumLength(20);
            RuleFor(createUserCommand =>
                createUserCommand.Email).EmailAddress().MaximumLength(50);
            RuleFor(createUserCommand =>
                createUserCommand.Password).NotEmpty().MaximumLength(100);
        }
    }
}
