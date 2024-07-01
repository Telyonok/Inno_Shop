using FluentValidation;

namespace UserManagementService.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(getUserByIdQuery => getUserByIdQuery.Id).GreaterThanOrEqualTo(0);
        }
    }
}
