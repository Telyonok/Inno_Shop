using FluentValidation;

namespace UserManagementService.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
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
