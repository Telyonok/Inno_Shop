using FluentValidation;

namespace UserManagementService.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator() 
        {
            RuleFor(deleteUserCommand => deleteUserCommand.Id).GreaterThanOrEqualTo(0);
        }
    }
}
